using System.Collections;
using UnityEngine;

public class FireBall : BaseSkill
{
    public override SkillType Type => SkillType.Fireball;

    public BulletData fireballData;

    public override BulletData BulletData => fireballData;

    public override void Attack(BulletSpawn bulletSpawn)
    {
        bulletSpawn.FireOneShot(fireballData);
    }
    protected override void OnLevelUp()
    {
        Debug.Log($"FireBall skill upgraded to level {level}");
        switch (level)
        {
            case 2:
                fireballData.Damage += 10;
                fireballData.Speed += 1f;
                fireballData.cooldown -= 0.5f;
                break;
            case 3:
                fireballData.Damage += 15;
                fireballData.Speed += 1f;
                fireballData.cooldown -= 0.5f;
                break;
            case 4:
                fireballData.Damage += 20;
                fireballData.Speed += 1f;
                fireballData.cooldown -= 0.5f;
                break;
            case 5:
                fireballData.Damage += 25;
                fireballData.Speed += 1f;
                break;
        }
    }
}