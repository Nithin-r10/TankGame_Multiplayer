using Unity.Netcode;
using UnityEngine;

public class DealDamage : NetworkBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private Health health;

    public void TakeDamage(int damage)
    {
        if (!IsServer) return;
        health.TakeDamage(damage);
    }
    
}
