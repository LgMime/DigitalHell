
using System.Collections;
using UnityEngine;

public class EnemyRange : Enemy 
{
    private CircleCollider2D _attackCollider;
    public float attackRange = 5f;
    public float FireRate = 3f;
    private float _lastFireTime;
    private Coroutine _attackRoutine;
    [SerializeField]
    private EnemyProjectileData _enemyProjectile;
    private void Start()
    {
        _attackCollider = GetComponentInChildren<CircleCollider2D>();
        if (_attackCollider != null)
        {
            _attackCollider.radius = attackRange;
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (_attackRoutine == null)
            {
                _attackRoutine = StartCoroutine(Attack());
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (_attackRoutine != null)
            {
                StopCoroutine(_attackRoutine);
                _attackRoutine = null;
            }
        }
    }
    private IEnumerator Attack()
    {
        while (true)
        {
            if (Time.time >= _lastFireTime + FireRate)
            {
                Shoot();
                _lastFireTime = Time.time;
            }
            yield return null;
        }       
    }

    private void Shoot()
    {
        GameObject bullet = ObjectPool.Instance.SpawnFromPool("Projectile", transform.position, Quaternion.identity);
        if (bullet != null)
        {
            bullet.GetComponent<RangeAttack>().Launch(gameObject, Player.Instance.transform.position, _enemyProjectile.speed, _enemyProjectile.damage, _enemyProjectile.knockbackForce);

        }
    }
}

