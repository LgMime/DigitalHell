using System.Collections;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    //!!!!!no singleton!!!!
    private ListEnemyEntry listEnemyEntry;
    private BulletRotate bulletRotate;
    private Coroutine attackRoutine;

    private void Awake()
    {
        bulletRotate = GetComponent<BulletRotate>();
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

    public IEnumerator SpawnBullet(BulletData data)
    {
        while (true)
        {
            if ( listEnemyEntry != null && listEnemyEntry.EnemyEntry.Count != 0 )
            {
                GameObject spawnbullet = Instantiate(data.bulletPrefab, transform.position, bulletRotate.GetRotation());       
                
                yield return new WaitForSeconds(data.cooldown);
            }
            else
                yield return new WaitForSeconds(0.1f);
            
        }
    }
  
}

