using Unity.Netcode;
using UnityEngine;

public class Animation : NetworkBehaviour
{
    [SerializeField]
    private InputReader _inputReader;
    [SerializeField]
    private Animator anima;

    public override void OnNetworkSpawn()
    {
        _inputReader.PrimaryFireEvent += fire;
    }
    public override void OnNetworkDespawn()
    {
        _inputReader.PrimaryFireEvent -= fire; 
    }
    void fire()
    {
        if (!IsOwner || anima == null) return;

        anima.SetTrigger("isshoot");
    }


}
