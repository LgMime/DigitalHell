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
            if (listEnemyEntry != null && listEnemyEntry.EnemyEntry.Count != 0)
            {
                bulletSpawn.SpawnBullet(data);             
                OnShoot?.Invoke();
                yield return new WaitForSeconds(data.cooldown);
             
            }          
            else
                yield return new WaitForSeconds(0.1f);          
        }
        
           
    }
}

