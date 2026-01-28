using Unity.Netcode;
using UnityEngine;

public class CoinCollector : NetworkBehaviour
{
    public NetworkVariable<int>Totalcoins = new NetworkVariable<int>();
    private int coinValue;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
           
            if (other.TryGetComponent<Coin>(out Coin coin))
            {
                Debug.Log("got inside the if condition ");
               int coinValue =  coin.Collect();
            }
            if (!IsServer) { return; }
            Totalcoins.Value += coinValue;
        }
    }
}
