using Assets.Scripts.Enemy;
using UnityEngine;

public class EnemyDie : MonoBehaviour, ITakeDamageEnemy
{
    public Enemy enemy;

    public event System.Action OnDie;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    public void TakeDamage(float damage)
    {
        enemy.health -= damage;
        DoDie();
    }
    private void DoDie() 
    {
        if (enemy.health <= 0)
        {
            OnDie?.Invoke();
            Destroy(gameObject);
        }
    }
}
