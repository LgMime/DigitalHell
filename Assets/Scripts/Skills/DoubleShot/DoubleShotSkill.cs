using System.Collections;
using UnityEngine;


public class DoubleShotSkill : BaseSkill
{

    public override SkillType Type => SkillType.DoubleShot;

    private BulletSpawn bulletSpawn;
    [SerializeField]
    private BulletData bulletData;
    [SerializeField]
    private float delayBetweenShots = 0.15f;


    private void Awake()
    {
        bulletSpawn = GetComponentInParent<BulletSpawn>();

        // ПРОВЕРКА 1: Нашли ли мы спавнер?
        if (bulletSpawn == null) Debug.LogError("ОШИБКА: DoubleShotSkill не нашел BulletSpawn в родителях!");
    }

    protected override void UseSkill()
    {
        Debug.Log($"1. Скилл активирован! Текущий уровень: {level}");
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        int bulletsToSpawn = level;


        for (int i = 0; i < bulletsToSpawn; i++)
        {
            yield return new WaitForSeconds(delayBetweenShots);

            if (bulletSpawn != null)
            {
                bulletSpawn.SpawnBullet(bulletData);
            }
            else
            {
                Debug.LogError("ОШИБКА: bulletSpawn == null, стрелять нечем!");
            }
        }
    }
}
