using System.Collections;
using UnityEngine;

public class MainWeapon : BaseSkill
{
    public override SkillType Type => SkillType.MainWeapon;

    [SerializeField] private float delayBetweenShots = 0.15f;

    [SerializeField] public BulletData bulletData;
    public override BulletData BulletData => bulletData;

    // Number of shots equals attention (level 1 = 1 bullet, level 2 = 2 bullets...)
    public override int BurstsCount => level;
    // Delay is taken from the inspector
    public override float BurstDelay => delayBetweenShots;
    public override void Attack(BulletSpawn bulletSpawn)
    {
        bulletSpawn.FireOneShot(bulletData);
    }
    protected override void OnLevelUp()
    {
        Debug.Log($"DoubleShot skill upgraded to level {level}");
        switch (level)
        {
            case 2:
                bulletData.Damage += 5;
                bulletData.Speed += 0.5f;
                break;
            case 3:
                bulletData.Damage += 10;
                bulletData.Speed += 0.5f;
                break;
            case 4:
                bulletData.Damage += 15;
                bulletData.Speed += 0.5f;
                break;
            case 5:
                bulletData.Damage += 20;
                bulletData.Speed += 0.5f;
                break;
        }
    }
}