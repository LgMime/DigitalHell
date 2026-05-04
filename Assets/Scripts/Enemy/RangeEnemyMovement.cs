using UnityEngine;

public class RangeEnemyMovement : EnemyMovement
{
    [SerializeField] private float attackRange = 5f;
    private EnemyRange _enemyRangeScript;
    protected override void Awake()
    {
        base.Awake();
        _enemyRangeScript = GetComponent<EnemyRange>();
    }


    protected override void MoveTo()
    {
        if (_enemyRangeScript != null && _enemyRangeScript._IsAttacking)
        {
            _rb.linearVelocity = Vector2.zero; 
            return; 
        }

        float distanceToPlayer = Vector2.Distance(transform.position, _playerTransform.position);

        if (distanceToPlayer <= attackRange)
        {
            _rb.linearVelocity = Vector2.zero;
            return;
        }

        Vector2 direction = ((Vector2)_playerTransform.position - _rb.position).normalized;
        _rb.MovePosition(_rb.position + direction * enemy.speed * Time.fixedDeltaTime);
    }

}
