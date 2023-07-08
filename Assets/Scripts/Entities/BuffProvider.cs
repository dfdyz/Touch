using Assets.Scripts.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffProvider : EntityBase
{
    [SerializeField]
    private float time = 30;

    [SerializeField]
    private int level = 1;

    [SerializeField]
    private BuffType Type = BuffType.None;

    [SerializeField]
    private Animator animtor;

    [SerializeField] 
    private Collider coll;

    public enum BuffType
    {
        None, Mass, Speed, Stun
    }

    private BuffBase GetBuff(out Type t)
    {
        BuffBase buff = null;
        t = null;
        if (Type == BuffType.Mass) {
            buff = new BuffBase.HeavyMassBuff(level, time);
            t = typeof(BuffBase.HeavyMassBuff);
        }
        else if (Type == BuffType.Speed) {
            buff = new BuffBase.HighSpeedBuff(level, time);
            t = typeof(BuffBase.HighSpeedBuff);
        }
        else if (Type == BuffType.Stun) {
            buff = new BuffBase.LowStunBuff(level, time);
            t = typeof(BuffBase.LowStunBuff);
        }
        return buff;
    }

    public override void GetDamage(float delta, PlayerEntity damager)
    {
        base.GetDamage(delta, damager);
        
        var hpRate = GetHPRate();
        if (hpRate > 40 && hpRate < 80)
        {
            animtor.Play("stage2");
        }
        else if(hpRate <= 40 && health > 0)
        {
            animtor.Play("stage3");
        }
    }

    protected override void KilledBy(PlayerEntity killer)
    {
        animtor.Play("broken");
        coll.enabled = false;
        BuffBase buff = GetBuff(out var type);
        //print(type);
        killer.SetBuff(type,buff);
        GameObject.Destroy(this,1.5f);
    }
}
