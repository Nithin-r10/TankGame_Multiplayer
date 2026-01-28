using Unity.Cinemachine;
using Unity.Netcode;
using UnityEngine;

public class Cameracontroll : NetworkBehaviour
{
    [SerializeField] private GameObject vCam;
    public override void OnNetworkSpawn()
    {
        if (!IsOwner) return;

        vCam.SetActive(true);

    }

}

