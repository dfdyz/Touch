using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Player;
using Input;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows;
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
    private AnimationCurve v_a_Curve;
    

    [SerializeField]
    private bool stun = true;

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

    public float getAccelerate(float v)
    {
        return v_a_Curve.Evaluate(v/maxSpeed);
    }

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
        return stun || GetHP() <= 0 || reborning;
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
        HandleReborn();
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
        rb.velocity = Vector3.zero;
        stun = false;
        strike = false;
        miss = false;
        SetHP(GetMaxHP());
        rebornPos = pos;
        reborning = true;
    }

    public void HandleReborn()
    {
        if(reborning)
        {
            Vector3 pos = transform.position;
            transform.position = Vector3.Lerp(pos, rebornPos, 0.05f);
            if((rebornPos - pos).magnitude <= 0.001f) reborning = false;
        }
    }

    private Dictionary<Type, BuffBase> BuffContainer = new Dictionary<Type, BuffBase>();
    public void SetBuff<T>(T buff) where T : BuffBase
    {
        if (BuffContainer.ContainsKey(typeof(T)))
        {
            BuffBase b = BuffContainer[typeof(T)];
            if (b.getLevel() < buff.getLevel() || b.getTime() < buff.getTime())
            {
                BuffContainer[typeof(T)] = buff;
            }
        }
        else
        {
            BuffContainer.Add(typeof(T), buff);
        }
    }

    public void GetBuff<T>(out T buff) where T : BuffBase
    {        
        if(BuffContainer.ContainsKey(typeof(T))) buff = (T)BuffContainer[typeof(T)];
        else buff = null;
    }


}
