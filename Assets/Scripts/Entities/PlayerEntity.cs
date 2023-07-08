using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UOP1.StateMachine;

public class PlayerEntity : EntityBase
{
    [Header("Components")]
    [SerializeField]
    private StateMachine stateMachine;

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
    private bool reborning = false;



    [SerializeField]
    private float mass = 10;

    private void Start()
    {
        rebornPos = transform.position;
    }

    public Vector3 GetDiraction()
    {
        return Vector3.one;
    }



    void Awake()
    {
        stateMachine.AttachComponent(this);
    }


    public bool isStun()
    {
        return stun && GetHP() > 0;
    }

    public bool isStriking()
    {
        return strike;
    }

    public bool isMiss()
    {
        return miss;
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

    private Vector3 rebornPos;
    public void ReBorn(Vector3 pos)
    {
        SetHP(GetMaxHP());
        rebornPos = pos;
        reborning = true;
    }

    public void HandleReborn()
    {
        if(reborning)
        {
            Vector3 pos = transform.position;
            transform.position = Vector3.Lerp(pos, rebornPos, 0.15f);
            if((rebornPos - pos).magnitude <= 0.001f) reborning = false;
        }
    }
}
