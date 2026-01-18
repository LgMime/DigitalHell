using UnityEngine;
using System.Collections;
using System;

public class EnemyDie : MonoBehaviour
{
    public event Action OnDie; // Событие для выпадения опыта

    [Header("Настройки")]
    [SerializeField] private float _destroyDelay = 1f; // ВРЕМЯ ЗАДЕРЖКИ
    [SerializeField] private HpDecrease _healthScript;

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
        // Автопоиск скрипта здоровья
        if (_healthScript == null) _healthScript = GetComponent<HpDecrease>();
    }

    private void OnEnable()
    {
        // Восстанавливаем врага при респавне
        if (_animator != null) _animator.Rebind();
        if (_collider != null) _collider.enabled = true;
        if (_movementScript != null) _movementScript.enabled = true;

        if (_healthScript != null) _healthScript.EnemyDoDie += StartDeathSequence;
    }

    private void OnDisable()
    {
        if (_healthScript != null) _healthScript.EnemyDoDie -= StartDeathSequence;
    }

    private void StartDeathSequence()
    {
        if (gameObject.activeInHierarchy)
        {
            OnDie?.Invoke(); // Дропаем опыт
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
        // 1. Запускаем анимацию
        if (_animator != null) _animator.SetTrigger("DoDie");

        // 2. Отключаем скрипт движения и коллайдер
        if (_movementScript != null){ _movementScript.StopKnockback(); _movementScript.enabled = false; }
        if (_collider != null) _collider.enabled = false;

        // 3. Ждем (Убедись, что в Инспекторе Destroy Delay > 0)
        yield return new WaitForSeconds(_destroyDelay);

        // 4. Исчезаем
        gameObject.SetActive(false);
    }
}