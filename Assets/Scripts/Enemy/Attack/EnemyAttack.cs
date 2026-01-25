using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Enemy _enemy;
    private void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int damage = _enemy.Damage;
            PlayerHealth.Instance.TakeDamage(damage);
        }    

    }
}
