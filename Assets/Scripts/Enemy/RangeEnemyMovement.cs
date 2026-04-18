using UnityEngine;

public class RangeEnemyMovement : EnemyMovement
{
    [SerializeField] private float attackRange = 5f;

    protected override void MoveTo()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, _playerTransform.position);
        if (distanceToPlayer > attackRange)
        {
            Vector2 direction = (_playerTransform.position - transform.position).normalized;
            _rb.MovePosition(_rb.position + direction * enemy.speed * Time.deltaTime);
        }
    }

}
