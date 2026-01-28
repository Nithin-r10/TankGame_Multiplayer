using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
   
   
    [SerializeField]
    private float MaxTimeToDestroy;
    [SerializeField]
    private GameObject [] ObjectToDestroy;


    private void Start()
    {
        DestorySelf();
    }

    private void DestorySelf()
    {

        Destroy(this.gameObject, MaxTimeToDestroy);
    }
}
