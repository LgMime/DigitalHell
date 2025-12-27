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
        if (bulletSpawn == null) Debug.LogError("ОШИБКА: DoubleShotSkill не нашел BulletSpawn в родителях!");
    }

    protected override void UseSkill()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        int bulletsToSpawn = level; // Или фиксированное число, как у тебя задумано

        for (int i = 0; i < bulletsToSpawn; i++)
        {
            if (bulletSpawn != null)
            {
                // 1. Ищем цель ПЕРЕД каждым выстрелом
                Vector3 targetPosition = transform.position + transform.up * 10f; // Дефолтная позиция

                if (GetEnemyPossition.Instance != null)
                {
                    Transform enemy = GetEnemyPossition.Instance.GetEnemy();
                    if (enemy != null)
                    {
                        targetPosition = enemy.position;
                    }
                }

                // 2. Стреляем в найденную позицию
                bulletSpawn.SpawnBullet(bulletData, targetPosition);
            }
            else
            {
                Debug.LogError("ОШИБКА: bulletSpawn == null, стрелять нечем!");
            }

            // Ждем перед следующим выстрелом
            yield return new WaitForSeconds(delayBetweenShots);
        }
    }
}