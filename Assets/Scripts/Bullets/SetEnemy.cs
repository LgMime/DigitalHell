using UnityEngine;

public class SetEnemy : MonoBehaviour
{
    public GameObject bullet;
    public BulletData bulletType;

    private void Awake()
    {
        bullet = gameObject;    
    }
    private void Start()
    {
        SetEnemyTarget();
    }
    public void SetEnemyTarget()
    {
       //game crashed when enemy die but skill try to set the died enemy
        Transform enemyTransform = GetEnemyPossition.Instance.GetEnemy();   
        if (enemyTransform == null) return;
        Vector3 pos = enemyTransform.position;
        LunchAttack lunchAttack = bullet.GetComponent<LunchAttack>();
        
        if (lunchAttack != null)
        {
            lunchAttack.SetTaregt(pos, bulletType);
        }
    }
}
