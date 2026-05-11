using UnityEngine;
using System.Collections;
using System;

public class EnemyHealth : BaseHealth
{
    [Header("Settings")]
    [SerializeField] private float _destroyDelay = 1f; 


    [Header("Link")]
    [SerializeField] private Enemy _enemyStats;

    private Animator _animator;
    private EnemyMovement _movementScript;
    private Collider2D _collider;
    private Rigidbody2D _rb2d;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _movementScript = GetComponent<EnemyMovement>();
        _collider = GetComponent<Collider2D>();
        _rb2d = GetComponent<Rigidbody2D>();


        if (_enemyStats == null) _enemyStats = GetComponent<Enemy>();
    }

    protected override void OnEnable()
    {
       
        if(_enemyStats != null)
        {
            maxHealth = (int)_enemyStats.health;
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

        if (_animator != null) _animator.SetTrigger("DoDie");

        if (_movementScript != null){ _movementScript.StopKnockback(); _movementScript.enabled = false; }
       

        yield return new WaitForSeconds(_destroyDelay);

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