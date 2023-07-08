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

    [SerializeField]
    private GameObject indicator;

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
        HandleIndicator();
    }

    void FixedUpdate()
    {
        rb.mass = getMass();
    }

    //public void SetC

    void OnCollisionEnter(Collision collision)
    {
        int layer = collision.collider.gameObject.layer;
        if (layer == Managers.GameLayers.World) return;
        
        if (layer == Managers.GameLayers.Player)
        {

        }

        if (layer == Managers.GameLayers.Entity)
        {

        }
        
    }

    private void HandleIndicator()
    {
        Vector3 v = rb.velocity;

        bool hide = v.magnitude < 0.1f;
        indicator.SetActive(!hide);

        if(hide)
        {
            return;
        }
        else
        {
            float ang = Vector2.SignedAngle(Vector2.right, new Vector2(v.x , v.z));
            indicator.transform.localRotation = Quaternion.Euler(0, -ang, 0);
        }



    }


}
