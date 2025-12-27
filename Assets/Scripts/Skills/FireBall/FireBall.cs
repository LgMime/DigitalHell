using System.Collections;
using UnityEngine;

public class FireBall : BaseSkill
{
    public override SkillType Type => SkillType.Fireball;

    public BulletData fireballData;
    public BulletSpawn BulletSpawner;

    private void Awake()
    {
        BulletSpawner = GetComponentInParent<BulletSpawn>();
    }

    // Запускаем таймер при старте игры (или когда скилл получен)
    private void Start()
    {
        StartCoroutine(AutoFireRoutine());
    }

    private IEnumerator AutoFireRoutine()
    {
        // Бесконечный цикл, как в SpawnTimer, но ЛИЧНЫЙ для фаербола
        while (true)
        {
            // Ждем перезарядку, указанную в Data фаербола (5 сек)
            yield return new WaitForSeconds(fireballData.cooldown);

            UseSkill(); // Стреляем
        }
    }

    protected override void UseSkill()
    {
        Vector3 targetPosition = GetTargetPosition();
        for (int i = 0; i < level; i++)
        {
            BulletSpawner.SpawnBullet(fireballData, targetPosition);
        }
      
    }

    private Vector3 GetTargetPosition()
    {
        if (GetEnemyPossition.Instance != null)
        {
            Transform enemy = GetEnemyPossition.Instance.GetEnemy();
            if (enemy != null) return enemy.position;
        }
        return transform.position + transform.up * 10f;
    }
}