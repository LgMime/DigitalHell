using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class BossAi : EnemyMovement, IKnockback
{
    [Header("State Flags")]
    public bool _isPreparing = false;
    public bool _isDashing = false;
    public bool _onCooldown = false;

    [Header("Settings")]
    public float prepareTime = 1f;
    public float cooldownTime = 3f;
    public float dashSpeedMultiplier = 2f;
    public float _stopDistance = 0.5f;

    [Header("Components")]
    public CircleCollider2D attackRangeCollider;

    public LayerMask playerLayer;

    private Vector2 _targetDashPoint;
    private Animator _animator; 

    protected override void Awake()
    {
        base.Awake();
        attackRangeCollider = GetComponentInChildren<CircleCollider2D>();
        _animator = GetComponent<Animator>();
    }

    private void UpdateAnimations()
    {
        if (_animator == null) return;

        bool shouldBePreparing = _isPreparing || _onCooldown;
        _animator.SetBool("Preparing", shouldBePreparing);

        _animator.SetBool("IsDashing", _isDashing);
    }
    public override void FixedUpdate()
    {
        if (_onCooldown || _isPreparing)
        {
            _rb.linearVelocity = Vector2.zero;
            return;
        }

        if (_isDashing)
        {

            Dash();
        }
        else
        {
            base.FixedUpdate();
        }

    }


    private void Dash()
    {
        Vector2 direction = (_targetDashPoint - _rb.position).normalized;
        float dist = Vector2.Distance(_rb.position, _targetDashPoint);

        if (dist > _stopDistance)
        {
            _rb.MovePosition(_rb.position + direction * (enemy.speed * dashSpeedMultiplier) * Time.fixedDeltaTime);
        }
        else
        {
            _isDashing = false;
            StartCoroutine(Cooldown());
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !_isDashing && !_onCooldown && !_isPreparing)
        {
            StartCoroutine(PreparingAttack());
        } 
    }
   

    public IEnumerator PreparingAttack()
    {

        _isPreparing = true;
        UpdateAnimations();
        yield return new WaitForSeconds(prepareTime);
        _targetDashPoint = Player.Instance.transform.position;
        _isPreparing = false;
        _isDashing = true;
        UpdateAnimations();
    }

    public IEnumerator Cooldown()
    {
        _onCooldown = true;
        UpdateAnimations();
        yield return new WaitForSeconds(cooldownTime);
        _onCooldown = false;
        UpdateAnimations();
        Flip();
        CheckForPlayerInRange();
    }

    private void CheckForPlayerInRange()
    {
        if (_isPreparing || _isDashing || _onCooldown || Player.Instance == null) return;

        float realRadius = attackRangeCollider.radius * attackRangeCollider.transform.lossyScale.x;
        float distance = Vector2.Distance(transform.position, Player.Instance.transform.position);

        if (distance <= realRadius)
        {
            StartCoroutine(PreparingAttack());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth.Instance?.TakeDamage(enemy.damage);
        }
    }

    public void OnDisable()
    {
        _isPreparing = false;
        _isDashing = false;
        _onCooldown = false;

    }
}

