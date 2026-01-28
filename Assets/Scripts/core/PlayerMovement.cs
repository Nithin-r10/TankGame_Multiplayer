using Unity.Netcode;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] private InputReader inputreader;
    [SerializeField] private Transform bodyTransform;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField]
    private float MovementSpeed = 4f;
    [SerializeField]
    private float TurningRate = 30f;
    private Vector2 previousMovementinput;
    // Update is called once per frame


    
    public override void OnNetworkSpawn()
    {
       if (!IsOwner) return;
       inputreader.MoveEvent += HandleMove;
    }
   
    private void FixedUpdate()
    {
        if (!IsOwner) return;

        float yRotation = previousMovementinput.x * TurningRate * Time.deltaTime;
        bodyTransform.Rotate(00, yRotation, 0);
        rigidbody.AddForce(bodyTransform.forward * previousMovementinput.y * MovementSpeed,ForceMode.Impulse);
    }
    private void HandleMove(Vector2 movementInput)
    {
        previousMovementinput = movementInput;
        Debug.Log("we have getting the movement evet" +  previousMovementinput); 
    }
    public override void OnNetworkDespawn()
    {
       if (!IsOwner) return;
       inputreader.MoveEvent -= HandleMove;
    }

}
