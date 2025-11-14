using System.Collections;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{

    private ListEnemyEntry listEnemyEntry;
    private Coroutine attackRoutine;
    //delegate void LunchAttack();
    //  public static event System.Action<Vector3, float> OnAttackLunched;

    private void Awake()
    {
        listEnemyEntry = GetComponentInParent<ListEnemyEntry>();
    }
    public void StartShooting(BulletData data)
    {
        if (attackRoutine == null)
            attackRoutine = StartCoroutine(CalculateRotate(data));
    }
    public void StopShooting()
    {
        if (attackRoutine != null)
        {
            StopCoroutine(attackRoutine);
            attackRoutine = null;
        }
    }

    public IEnumerator CalculateRotate(BulletData data)
    {
        while (true)
        {
            if (listEnemyEntry.EnemyEntry.Count != 0 && listEnemyEntry != null)
            {

                Transform target = listEnemyEntry.EnemyEntry[0].transform;
                if (target != null)
                {
                    Vector3 targetPos = target.position;
                    Vector3 PlayerPos = Player.Instance.transform.position;

                    Vector3 direction = (targetPos - PlayerPos).normalized;

                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                    Quaternion bulletRotation = Quaternion.Euler(new Vector3(0f, 0f, angle + 90));
                    GameObject bullet = Instantiate(data.bulletPrefab, transform.position, bulletRotation); //transform.position use manager position for spawn bullet

                    LunchAttack lunchAttack = bullet.GetComponent<LunchAttack>();
                    if (lunchAttack != null)
                    {
                        lunchAttack.SetTaregt(target.position, data);
                    }
                }       
                // OnAttackLunched?.Invoke(direction, typeA.damage);
                yield return new WaitForSeconds(data.cooldown);
            }
            else
            {
                // если нет врагов Ч ждЄм чуть-чуть и провер€ем снова
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}

