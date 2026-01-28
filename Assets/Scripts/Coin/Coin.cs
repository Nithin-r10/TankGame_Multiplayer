using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Coin : NetworkBehaviour
{
    [SerializeField] private MeshRenderer meshrender;

    protected int Coinvalue;
    protected bool alreadyCollected;

    public abstract int Collect();

    public void Setvalue(int value)
    {
        Coinvalue = value;
    }
    protected void Show (bool show)
    {
        meshrender.enabled = show;
    }
}
