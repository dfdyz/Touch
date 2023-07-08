using System.Collections;
using System.Collections.Generic;
using Input;
using UnityEngine;
using UOP1.StateMachine;

public class PlayerEntity : EntityBase
{
    [Header("Components")]
    [SerializeField]
    private StateMachine stateMachine;
    
    [SerializeField]
    private PlayerInput playerInput;
   
    public Rigidbody rb;

    [Header("Arguements")]
    [SerializeField]
    private float maxSpeed = 5;

    [SerializeField]
    private bool stun = false;

    [SerializeField]
    private bool strike = false;
    [SerializeField]
    private bool miss = false;
    
    [SerializeField]
    private float mass = 10;
    

    public Vector3 GetDiraction()
    {
        return playerInput.Direction;
    }
    

    void Awake()
    {
        stateMachine.AttachComponent(this);
    }


    public bool isStun()
    {
        return stun;
    }

    public bool isStriking()
    {
        return playerInput.IsStriking;
    }

    public bool isMiss()
    {
        return playerInput.IsMissing;
    }

    public float getMass()
    {
        return mass;
    }

    public float getMaxSpeed()
    {
        return maxSpeed;
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
