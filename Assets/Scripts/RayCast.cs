using Unity.Netcode;
using UnityEngine;

public class RayCast : NetworkBehaviour
{
    [SerializeField]
    private GameObject cam;
    [SerializeField]
    private InputReader inputreader;
    RaycastHit hitinfo;
    [SerializeField]
    private GameObject clintprojectile;
    [SerializeField]
    private Transform ProjectilePosition;
    [SerializeField]
    private ParticleSystem MuzzleFlash;
    [SerializeField]
    private float canfire = 2;
    [SerializeField]
    private int Damage = 20;
   


    public override void OnNetworkSpawn()
    {
        if (!IsOwner) return;
         //Debug.Log("now the handlefire is calling ");
        inputreader.PrimaryFireEvent += HandleFire;
   
    }
    public override void OnNetworkDespawn()
    {
        if (!IsOwner) return;
        inputreader.PrimaryFireEvent -= HandleFire;

    }
    private void Update()
    {
        if (!IsOwner) return;
        canfire -= Time.deltaTime;
       // Debug.Log(canfire + " the canfire is ");

    }
    void HandleFire()
    {
        if (canfire <= 0)
        {
            SpwnDummyProjectile(); //  the server phone instatiate the dummy projectile first to see the server player 
            PrimaryFireServerRpc(cam.transform.position, cam.transform.forward); // then calls server rpc which instatiate a raycast from the server
            canfire = 10;

        }

    }
    [ServerRpc]
    private void PrimaryFireServerRpc(Vector3 pos , Vector3 direction) //  calls the main server 
    {
       
        Raycasting(pos, direction); // its calls the raycast methord
        ClintDummyClientRpc();  //  we have to call this clintrpc from server rpc to brodcast the function of instatating the dummy projetile
    }
    [ClientRpc]  // the clint rpc is use to brodcast to all the clints 
   private void ClintDummyClientRpc() // clint rpc is used to brodcast message 
    {
        if (IsOwner) return;
        SpwnDummyProjectile();
    }
    private void Raycasting(Vector3 Orgin, Vector3 Direction)
    {
        
            //Debug.Log(" the raycasting methord is being triggered");
            if (Physics.Raycast(Orgin, Direction, out hitinfo, 1000))
            {
              hitinfo.transform.GetComponent<Health>().TakeDamage(Damage);
               // Debug.Log("the raycast is hitten object" + hitinfo.transform.name);
                Debug.DrawRay(Orgin, Direction * 1000, Color.red, 2f);

            }
        
     
    }
    void SpwnDummyProjectile()
    {
        MuzzleFlash.Play();
        Instantiate(clintprojectile, ProjectilePosition.position, Quaternion.identity);
    }
}
