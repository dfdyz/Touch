using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : EntityBase
{
    [SerializeField]
    private bool stun = false;
    public bool isStun()
    {
        return stun;
    }

    void Update()
    {
        
    }

    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("World")) return;

        
    }


}
