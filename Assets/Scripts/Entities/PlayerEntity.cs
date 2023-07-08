using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UOP1.StateMachine;

public class PlayerEntity : EntityBase
{
    [Header("Components")]
    [SerializeField]
    private StateMachine stateMachine;
    [SerializeField]
    private Rigidbody rb;

    [Header("Arguements")]
    [SerializeField]
    private bool stun = false;

    [SerializeField]
    private float mass = 10;



    void Awake()
    {
        stateMachine.AttachComponent(this);
    }


    public bool isStun()
    {
        return stun;
    }

    public float getMass()
    {
        return mass;
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rb.mass = getMass();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("World")) return;

        
    }


}
