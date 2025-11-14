using Assets.Scripts.Enemy;
using UnityEngine;

public class LunchAttack : MonoBehaviour
{
    private float speed;
    private float damage;
    public Vector3 targetPosition;
    private bool TargetSet = false;

    public void SetTaregt(Vector3 pos, BulletData bulletType)
    {
        targetPosition = pos;
        TargetSet = true;
        speed = bulletType.speed;
        damage = bulletType.damage;

    }
    private void Update()
    {
        if (!TargetSet) return;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ITakeDamageEnemy enemy = collision.gameObject.GetComponent<ITakeDamageEnemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}

