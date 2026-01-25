using UnityEngine;
using System.Collections;
using System;

public class EnemyHealth : BaseHealth
{
    [Header("Настройки")]
    [SerializeField] private float _destroyDelay = 1f; // ВРЕМЯ ЗАДЕРЖКИ


    [Header("Link")]
    [SerializeField] private Enemy _enemyStats;

    private Animator _animator;
    private MoveToPlayer _movementScript;
    private Collider2D _collider;
    private Rigidbody2D _rb2d;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _movementScript = GetComponent<MoveToPlayer>();
        _collider = GetComponent<Collider2D>();
        _rb2d = GetComponent<Rigidbody2D>();


        if (_enemyStats == null) _enemyStats = GetComponent<Enemy>();
    }

    protected override void OnEnable()
    {
        // Восстанавливаем врага при респавне
       
        if(_enemyStats != null)
        {
            maxHealth = _enemyStats.health;
        }
        base.OnEnable();
        ResetEnemyState();
    }
 
    protected override void Die()
    {
        base.Die();     
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(DieRoutine());
        }
    }

    private IEnumerator DieRoutine()
    {

        if (_rb2d != null)
        {
            _rb2d.linearVelocity = Vector2.zero;
            _rb2d.bodyType = RigidbodyType2D.Kinematic;
        }
        if (_collider != null) _collider.enabled = false;
        // 1. Запускаем анимацию
        if (_animator != null) _animator.SetTrigger("DoDie");

        // 2. Отключаем скрипт движения и коллайдер
        if (_movementScript != null){ _movementScript.StopKnockback(); _movementScript.enabled = false; }
       

        // 3. Ждем (Убедись, что в Инспекторе Destroy Delay > 0)
        yield return new WaitForSeconds(_destroyDelay);

        // 4. Исчезаем
        gameObject.SetActive(false);
    }

    private void ResetEnemyState()
    {
        if (_animator != null) _animator.Rebind();
        if (_collider != null) _collider.enabled = true;
        if (_movementScript != null) _movementScript.enabled = true;
        if (_rb2d != null) _rb2d.bodyType = RigidbodyType2D.Dynamic;
    }
}