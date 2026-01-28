using UnityEngine;
using Unity.Netcode;
using System;
public class Health : NetworkBehaviour
{
    bool isDead = false;
    public Action<Health> OnDie;
   [field : SerializeField] public int MaxHealth { get; private set; } = 100;

    public NetworkVariable<int> CurrentHealth = new NetworkVariable<int>();
    public override void OnNetworkSpawn()
    {
       if (!IsServer) return;

       CurrentHealth.Value = MaxHealth; // the current health varible is a network varible that why even tho
                                        // a clint is not a server its health aslo set to 100 automatically
                                        // but the clint is not a server cant change the current health a sever
                                        // is the only can change the network varible
        Debug.Log("onnetworkspwn is working the current health is " + CurrentHealth.Value);
    }
    public void TakeDamage(int damageValue)
    {
        ModifieHealth(-damageValue);
    }
    public void RestoreHealth(int healValue)
    {
        ModifieHealth(healValue);
    }
    private void ModifieHealth(int value)
    {
        if (isDead) return;
        int newHealth = CurrentHealth.Value + value;

        newHealth = Mathf.Clamp(newHealth, 0, MaxHealth);

        CurrentHealth.Value = newHealth;
        if (newHealth <= 0)
        {
            OnDie?.Invoke(this);
            isDead = true;
        }
    }
}
