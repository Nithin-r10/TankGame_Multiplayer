using Unity.Netcode.Components;
using UnityEngine;

public class ClientNetworkTransform : NetworkTransform
{
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        CanCommitToTransform = IsOwner;
    }

    protected override bool OnIsServerAuthoritative()
    {
        return false; // Client authoritative
    }

    public override void OnUpdate()
    {
        CanCommitToTransform = IsOwner;
        base.OnUpdate(); // This handles the transform syncing automatically
    }
}