using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBase : MonoBehaviour
{
    [SerializeField]
    protected float health = 100;

    [SerializeField]
    protected float maxHealth = 100;
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        health = maxHealth;
    }

    public float GetHP()
    {
        return health;
    }

    public virtual float GetMaxHP()
    {
        return maxHealth;
    }

    public virtual bool ShouldRemove()
    {
        return IsAlive();
    }

    public bool IsAlive()
    {
        return health > 0;
    }

    public void SetHP(float hp)
    {
        health = hp;
    }

    public float GetHPRate()
    {
        return GetHP()/GetMaxHP();
    }

    public void Heal(float hp)
    {
        health = Mathf.Clamp(health + hp, 0, GetMaxHP());
    }
}
