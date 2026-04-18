
using System;
using UnityEngine;

public abstract class AbstractAura: BaseSkill, IActiveSkill
{
    [SerializeField]protected AuraData auraData;
    public override float Cooldown => auraData.Cooldown;
    public override void Active()
    {

    }
}

