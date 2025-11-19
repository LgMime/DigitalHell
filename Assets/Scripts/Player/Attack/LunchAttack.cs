using Assets.Scripts.Enemy;
using UnityEngine;

public class LunchAttack : MonoBehaviour
{
    private float _attackSpeed;
    private float _damage;
    public Vector3 targetPosition;
    private bool TargetSet = false;

    public void SetTaregt(Vector3 pos, BulletData bulletType)
    {
        targetPosition = pos;
        TargetSet = true;
        _attackSpeed = bulletType.speed;
        _damage = bulletType.damage;

    }
    private void Update()
    {
        if (!TargetSet) return;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, _attackSpeed * Time.deltaTime);
        if(Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ITakeDamageEnemy enemy = collision.gameObject.GetComponent<ITakeDamageEnemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(_damage);
            }
            Destroy(gameObject);

        }

        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}

