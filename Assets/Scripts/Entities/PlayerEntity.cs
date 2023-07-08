using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UOP1.StateMachine;

public class PlayerEntity : EntityBase
{
    [SerializeField]
    private StateMachine stateMachine;

    [SerializeField]
    private bool stun = false;

    void Awake()
    {
        stateMachine.AttachComponent(this);
    }


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
