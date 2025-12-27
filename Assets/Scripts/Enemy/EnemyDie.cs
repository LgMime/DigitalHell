using UnityEngine;
using System.Collections; // Обязательно для IEnumerator

public class EnemyDie : MonoBehaviour, ITakeDamageEnemy
{
    public Enemy enemy;
    public event System.Action OnDie;

    [SerializeField] private float _destroyDelay = 0.3f;
    private Animator _animator;
    private bool _isDead = false;

    // Кэшируем ссылку на движение, чтобы не искать её каждый раз
    private MoveToPlayer _movementScript;
    private Collider2D _collider;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        _animator = GetComponentInChildren<Animator>();
        _movementScript = GetComponent<MoveToPlayer>(); // Получаем твой скрипт
        _collider = GetComponent<Collider2D>();
    }

    // Если враги переиспользуются (Object Pooling), нужно сбрасывать флаг при включении
    private void OnEnable()
    {
        _isDead = false;

        // 1. Включаем коллайдер обратно (для следующего спавна)
        if (_collider != null) _collider.enabled = true;

        // 2. ВАЖНО: Включаем скрипт движения обратно!
        // Иначе возрожденный враг будет стоять на месте.
        if (_movementScript != null) _movementScript.enabled = true;
    }

    public void TakeDamage(float damage)
    {
        if (_isDead) return; // Мертвые не получают урон

        enemy.health -= damage;

        if (enemy.health <= 0)
        {
            StartCoroutine(DieProcess());
        }
    }

    private IEnumerator DieProcess()
    {
        _isDead = true;

        OnDie?.Invoke();

        if (_animator != null) _animator.SetTrigger("DoDie");

        // 3. Отключаем физику
        if (_collider != null) _collider.enabled = false;

        // 4. Отключаем ТВОЙ скрипт движения
        // Теперь враг мгновенно остановится и проиграет анимацию на месте
        if (_movementScript != null) _movementScript.enabled = false;

        yield return new WaitForSeconds(_destroyDelay);

        gameObject.SetActive(false);
    }
}