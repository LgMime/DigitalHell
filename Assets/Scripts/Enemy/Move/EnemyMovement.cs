using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour, IKnockback
{
    [SerializeField] public Enemy enemy;
    public Rigidbody2D _rb;
    public Transform _playerTransform;

    private bool _isKnockback = false;
    public Coroutine _isKnockbackCoroutine;
    public float _defaultMass = 4f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        if (enemy == null) enemy = GetComponent<Enemy>();
        if (Player.Instance != null) _playerTransform = Player.Instance.transform;
    }

    public virtual void FixedUpdate()
    {
        if (_isKnockback || _playerTransform == null) return;

        MoveTo();
    }

    protected virtual void MoveTo()
    {

        Vector2 direction = (_playerTransform.position - transform.position).normalized;
        _rb.MovePosition(_rb.position + direction * enemy.speed * Time.deltaTime);

    }
    public void ApllyKnockback(float force)
    {
        if (_isKnockbackCoroutine != null)
        {
            StopCoroutine(_isKnockbackCoroutine);
        }
        _rb.mass = _defaultMass * 50f;
        Vector2 knockbackDirection = (_rb.position - (Vector2)_playerTransform.position).normalized;

        _rb.linearVelocity = Vector2.zero;
        _rb.AddForce(knockbackDirection * force, ForceMode2D.Impulse);
        _isKnockback = true;

        _isKnockbackCoroutine = StartCoroutine(EndKnockback());
    }
    private IEnumerator EndKnockback()
    {
        yield return new WaitForSeconds(0.2f);
        _rb.linearVelocity = Vector2.zero;
        _isKnockback = false;
    }
    public void StopKnockback()
    {
        if (_isKnockbackCoroutine != null)
        {
            StopCoroutine(_isKnockbackCoroutine);
            _rb.linearVelocity = Vector2.zero;
        }
        if (_rb != null)
        {
            _rb.mass = _defaultMass;
            _rb.linearVelocity = Vector2.zero;
        }
        _isKnockback = false;
    }
}