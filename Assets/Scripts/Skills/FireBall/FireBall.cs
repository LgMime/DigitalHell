using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : AbstractProjectile
{
    BulletSpawn spawner;
    SpawnTimer spawntimer;
    public override SkillType Type => SkillType.Fireball;


    public BulletData fireballData;

    public override BulletData BulletData => fireballData;
    private void Awake()
    {
        fireballData = Instantiate(fireballData);
        spawner = GetComponentInParent<BulletSpawn>();
        spawntimer = GetComponentInParent<SpawnTimer>();
    }
    public override void Active()
    {
        if (spawner != null) 
        { 
            spawner.FireOneShot(fireballData);
        }
        StartCoroutine(spawntimer.Timer(Active, Cooldown));
    }

    protected override void OnLevelUp()
    {
        
        Debug.Log($"FireBall skill upgraded to level {level}");
        if (level > 1 && level < 5)
        {
            fireballData.Damage += 5; // Increase damage for the first bullet
            fireballData.Speed += 1f;
            fireballData.cooldown -= 0.5f;
        }
        else if (level == 5)
        {
            fireballData.Damage += 5;
            fireballData.Speed += 1f;
        }
    }
}