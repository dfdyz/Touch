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

    protected override void KilledBy(PlayerEntity killer)
    {
        BuffBase buff = GetBuff(out var type);
        //print(type);
        killer.SetBuff(type,buff);
        GameObject.Destroy(gameObject);
    }
}
