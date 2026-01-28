using UnityEngine;
using Unity.Netcode;
using System.Collections.Generic;
using System.Collections;
public class JoinServer : MonoBehaviour
{
    public void Join()
    {
        NetworkManager.Singleton.StartClient();
    }
    public void host()
    {
        NetworkManager.Singleton.StartHost();
    }
}
