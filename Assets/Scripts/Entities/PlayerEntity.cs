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
    [Header("Event Broadcast")]
    [SerializeField]
    private IntEventChannelSO playerDieEvent;
    
    [Header("Components")]
    [SerializeField]
    private StateMachine stateMachine;
    
    [SerializeField]
    private PlayerInput playerInput;

    [SerializeField]
    private GameObject indicator;

    [SerializeField]
    private CapsuleCollider hitBox;
    [SerializeField]
    private CapsuleCollider castBox;

    [SerializeField]
    private GameObject Sprite;

    public Rigidbody rb;

    [Header("Arguements")] 
    [SerializeField]
    private PlayerID id;
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
    [HideInInspector] 
    public bool isWinning = false;

    [SerializeField]
    private float mass = 10;

    private bool strikeCoolDown = false;
    private bool missCoolDown = false;

    public void SetHitBoxPosY(float Y)
    {
        hitBox.center = new Vector3(0,Y+1,0);
        castBox.center = hitBox.center;
        Sprite.transform.localPosition = new Vector3(0, Y, 0);
    }
    private void Start()
    {
        rebornPos = transform.position;
    }

    public float getAccelerate(float v)
    {
        return v_a_Curve.Evaluate(v/getMaxSpeed());
    }

    public void setStun(bool stun)
    {
        this.stun = stun;
    }

    public Vector3 GetDiraction()
    {
        if (isWinning || reborning) return Vector3.zero;
        return playerInput.Direction;
    }
    
    public float getStunTime()
    {
        GetBuff<BuffBase.LowStunBuff>(out var buff);
        if (buff != null)
        {
            return 0.6f + buff.value();
        }
        return 0.6f;
    }
    void Awake()
    {
        stateMachine.AttachComponent(this);
    }


    public bool isStun()
    {
        return stun || GetHP() <= 0 || reborning;
    }

    public bool isStriking
    {
        get
        {
            return strike;
        }
    }

    public bool isMiss
    {
        get
        {
            return miss;
        }
    }

    public float getMass()
    {
        GetBuff<BuffBase.HeavyMassBuff>(out var buff);
        if (buff != null){
            return mass + buff.value(); }
        return mass;
    }

    public float getMaxSpeed()
    {
        GetBuff<BuffBase.HighSpeedBuff>(out var buff);
        if (buff != null)
        {
            return maxSpeed + buff.value();
        }
        return maxSpeed;
    }

    private IEnumerator CoolDown(int type, float time = 1.8f)
    {
        if(type == 0)
        {
            strikeCoolDown = true;
            yield return new WaitForSeconds(time);
            strikeCoolDown = false;
        }
        else
        {
            missCoolDown = true;
            yield return new WaitForSeconds(time);
            missCoolDown = false;
        }
    }

    private void Strike()
    {
        if (playerInput.IsStriking)
        {
            playerInput.IsStriking = false;

            if(GetDiraction().magnitude > 0.5f && !strike && !miss && !strikeCoolDown)
            {
                StartCoroutine(Striking());
            }
        }
    }

    private void Miss()
    {
        if (playerInput.IsMissing)
        {
            playerInput.IsMissing = false;
            if (!strike && !miss && !missCoolDown)
            {
                StartCoroutine(Missing());
            }

        }
    }

    private IEnumerator Striking()
    {
        strike = true;
        yield return new WaitForSeconds(0.1f);
        strike = false;
        StartCoroutine(CoolDown(0));
    }

    private IEnumerator Missing()
    {
        miss = true;
        yield return new WaitForSeconds(0.4f);
        miss = false;
        StartCoroutine(CoolDown(1));
    }

    void Update()
    {
        HandleIndicator();
        HandleReborn();
        Strike();
        Miss();
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
        //indicator.SetActive(!hide);

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
            if((rebornPos - pos).magnitude <= 0.01f) reborning = false;
        }
    }

    public override void GetDamage(float delta)
    {
        if (reborning) return;
        base.GetDamage(delta);
        if (health <= 0)
        {
            health = 0;
            playerDieEvent.RaiseEvent((int)id);
        }
    }

    private Dictionary<Type, BuffBase> BuffContainer = new Dictionary<Type, BuffBase>();
    public void SetBuff<T>(Type t,T buff) where T : BuffBase
    {
        if (BuffContainer.ContainsKey(typeof(T)))
        {
            BuffBase b = BuffContainer[typeof(T)];
            if (!b.isAlive()) BuffContainer[typeof(T)] = buff;
            else if (b.getLevel() < buff.getLevel() || b.getTime() < buff.getTime())
            {
                BuffContainer[t] = buff;
            }
        }
        else
        {
            BuffContainer[t] = buff;
        }
    }

    public void GetBuff<T>(out T buff) where T : BuffBase
    {        
        if(BuffContainer.ContainsKey(typeof(T))) buff = (T)BuffContainer[typeof(T)];
        else buff = null;
    }

    public void HandleBuff(float dt)
    {
        foreach(KeyValuePair<Type,BuffBase> t_buff in BuffContainer)
        {
            if (t_buff.Value.isAlive())
            {
                t_buff.Value.upd(this,dt);
            }
        }
    }
}
