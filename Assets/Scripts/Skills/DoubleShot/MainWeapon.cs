using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainWeapon : AbstractProjectile
{
    public override SkillType Type => SkillType.MainWeapon;
    SpawnTimer spawntimer;
    BulletSpawn spawner;


    [SerializeField] private float delayBetweenShots = 0.15f;

    [SerializeField] public BulletData bulletData;
    public override BulletData BulletData => bulletData;

    // Number of shots equals attention (level 0 = 1 bullet, level 1 = 2 bullets...)
    public override int BurstsCount => level;
    // Delay is taken from the inspector
    public override float BurstDelay => delayBetweenShots;
    public void Awake()
    {
        bulletData = Instantiate(bulletData);
        spawntimer = GetComponentInParent<SpawnTimer>();
        spawner = GetComponentInParent<BulletSpawn>();
        level = 1; // Start at level 1 for immediate double shot

    }
    public override void Active()
    {
        Attack();
       StartCoroutine(spawntimer.Timer(Active, Cooldown));
    }
    private void Attack()
    {
        StartCoroutine(Delay());
    }
    private IEnumerator Delay()
    {
        for (int i = 0; i < BurstsCount; i++)
        {
            spawner.FireOneShot(bulletData);
            yield return new WaitForSeconds(delayBetweenShots);
        }
        
    }
     Dictionary<int, Action> levelup = new Dictionary<int, Action>();// ToDo split lvlup logic into separate methods 1 for double shot and 1 for damage/speed increase


    protected override void OnLevelUp()
    {
        Debug.Log($"DoubleShot skill upgraded to level {level}");
        if (level > 1)
        {
            bulletData.Damage += 5; // Increase damage for the first bullet
            bulletData.Speed += 0.5f;  

        }
    }
}