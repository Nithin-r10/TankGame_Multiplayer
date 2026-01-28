using Unity.Netcode;
using UnityEngine;

public class PlayerAiming : NetworkBehaviour
{
   // [SerializeField] private InputReader inputreader;
    [SerializeField] private Transform turretTransform;
    [SerializeField] private Transform camera;
    

 
    private void LateUpdate()
    {
        if (!IsOwner) return;

        Vector3 direction = camera.transform.forward;
        turretTransform.forward = direction;

      
    }


 
}