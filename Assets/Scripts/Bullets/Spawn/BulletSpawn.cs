using System.Collections;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    private BulletRotate bulletRotate;

    private void Awake()
    {
        bulletRotate = GetComponent<BulletRotate>();
    }

    // Добавили аргумент targetPos - куда лететь
    public void FireOneShot(BulletData data)
    {
        // 1. Проверяем, что данные пришли
        if (data == null || data.BulletPrefab == null)
        {
            Debug.LogError("BulletSpawn: В BulletData нет префаба!");
            return;
        }

        // 2. Сначала ищем врага (чтобы не спавнить пулю зря, если врагов нет)
        Transform targetTransform = null;
        if (GetEnemyPossition.Instance != null)
        {
            targetTransform = GetEnemyPossition.Instance.GetEnemy();
        }

        // Если врага нет — выходим
        if (targetTransform == null) return;

        // 3. Пытаемся достать пулю
        string prefabName = data.BulletPrefab.name;

        GameObject bulletObj = ObjectPool.Instance.SpawnFromPool(
            prefabName,
            transform.position,
            bulletRotate.GetRotation()
        );

        // --- ВАЖНАЯ ЗАЩИТА (Которой у тебя не было) ---
        if (bulletObj == null)
        {
            Debug.LogError($"!!! ОШИБКА !!! ObjectPool вернул NULL.\n" +
                           $"Он искал пул с именем: '{prefabName}'\n" +
                           $"1. Проверь, нет ли пробелов внутри кавычек в ошибке.\n" +
                           $"2. Проверь, что в ObjectPool есть пул с точно таким именем.\n" +
                           $"3. Проверь, что Size у пула достаточно большой (поставь 50+).");
            return; // Останавливаемся, чтобы игра не крашнулась
        }
        // ----------------------------------------------

        // 4. Запускаем пулю
        ProjectileBase projectile = bulletObj.GetComponent<ProjectileBase>();

        if (projectile != null)
        {
            projectile.Launch(targetTransform.position, data.Speed, data.Damage, data.KnockbackForce);
        }
        else
        {
            Debug.LogError($"На объекте '{bulletObj.name}' нет скрипта ProjectileBase!");
        }
    }
}