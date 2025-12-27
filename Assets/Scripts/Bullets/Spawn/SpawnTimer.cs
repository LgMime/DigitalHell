using System.Collections;
using UnityEngine;

public class SpawnTimer : MonoBehaviour
{
    public event System.Action OnShoot;

    private ListEnemyEntry listEnemyEntry;
    private Coroutine attackRoutine;

    private void Awake()
    {
        listEnemyEntry = GetComponentInParent<ListEnemyEntry>();
    }

    public void StopShooting()
    {
        if (attackRoutine != null)
        {
            StopCoroutine(attackRoutine);
            attackRoutine = null;
        }
    }

    public IEnumerator StartSpawnTimer(BulletData data, BulletSpawn bulletSpawn)
    {
        while (true)
        {
            // Проверяем, есть ли враги в списке
            if (listEnemyEntry != null && listEnemyEntry.EnemyEntry.Count != 0)
            {
                // 1. Пытаемся получить врага через твой синглтон
                Transform targetTransform = null;
                
                if (GetEnemyPossition.Instance != null)
                {
                    targetTransform = GetEnemyPossition.Instance.GetEnemy();
                }

                // 2. ВАЖНО: Проверяем на null ДО того, как берем .position
                if (targetTransform != null)
                {
                    // Враг жив! Передаем его позицию в спавнер
                    bulletSpawn.SpawnBullet(data, targetTransform.position);
                    
                    OnShoot?.Invoke();
                    yield return new WaitForSeconds(data.cooldown);
                }
                else
                {
                    // Враг был в списке, но GetEnemy вернул null (например, он только что умер)
                    // Ждем кадр, чтобы не зависнуть, и ищем нового
                    yield return null; 
                }
            }          
            else
            {
                yield return new WaitForSeconds(0.1f);          
            }
        }
    }
}