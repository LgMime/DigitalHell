
using System.Collections;
using UnityEngine;

public class EnemyRange : Enemy
{
    private CircleCollider2D _attackCollider;
    public float attackRange = 5f;
    public float FireRate = 3f;
    public float postShotPause = 0.5f;
    private float _lastFireTime;
    private Coroutine _attackRoutine;
    [SerializeField]
    private EnemyProjectileData _enemyProjectile;

    private Animator _animator;
    private Rigidbody2D _rb2d;
    public bool _IsAttacking = false;

    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _attackCollider = GetComponentInChildren<CircleCollider2D>();
        _animator = GetComponent<Animator>();
        if (_attackCollider != null)
        {
            _attackCollider.radius = attackRange;
        }

    }
    private void FixedUpdate()
    {
        if (_IsAttacking)
        {
            _rb2d.linearVelocity = Vector2.zero;
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
            if (_animator != null)
            {
                _animator.SetBool("InChase", false);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (_attackRoutine != null)
            {
                if (_animator != null)
                {
                    _animator.SetBool("InChase", true);
                }
                StopCoroutine(_attackRoutine);
                _attackRoutine = null;
            }
        }
    }
    private IEnumerator Attack()
    {
        while (true)
        {
            float timeSinceLastShot = Time.time - _lastFireTime;

            if (timeSinceLastShot < FireRate)
            {
                if (_animator != null) _animator.SetBool("InChase", true);
                _IsAttacking = false;
                yield return new WaitForSeconds(FireRate - timeSinceLastShot);
            }

            _IsAttacking = true;
            if (_animator != null) _animator.SetBool("InChase", false);

            Shoot();
            _lastFireTime = Time.time;

            yield return new WaitForSeconds(postShotPause);

            yield return new WaitForSeconds(Mathf.Max(0, FireRate - postShotPause));
            _IsAttacking = false;
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

