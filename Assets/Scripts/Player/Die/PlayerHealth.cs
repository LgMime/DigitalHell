using System.Collections;
using UnityEngine;


public class PlayerHealth : BaseHealth
{
    public static PlayerHealth Instance { get; private set; }

    private Animator _animator; // Link to the Animator component
    [SerializeField]private bool _isInvincible = false;


    private void Awake()
    {
        // Если место занято - просто уходим. НЕ УНИЧТОЖАЕМ ОБЪЕКТ.
        if (Instance != null && Instance != this)
        {
            return;
        }

        Instance = this;
        _animator = GetComponent<Animator>();
    }

    public override void TakeDamage(float damage)
    {

        if (_isInvincible)
        {

            Debug.Log("[PlayerHealth] Урон игнорируется: Включена неуязвимость.");
            return;
        }
     
        base.TakeDamage(damage);
        Debug.Log($"[PlayerHealth] ПОЛУЧЕН СИГНАЛ УРОНА: {damage}");

        if (currentHealth > 0f)
            StartCoroutine(InvincibilityFrames(Player.Instance.InvincibilityDuration));
    }
    public IEnumerator InvincibilityFrames(float duration)
    {
        _isInvincible = true;
        // Here you can add visual feedback for invincibility, like flashing the player sprite
        yield return new WaitForSeconds(duration);
        _isInvincible = false;

    }

    protected override void Die()
    {
        base.Die();
        StartCoroutine(DeatgRunTime());
    }

    private IEnumerator DeatgRunTime()
    {
        // Start the death animation and disable movement
        if (_animator != null)
        {
            _animator.SetTrigger("DoDie");
        }

        var movement = GetComponent<Movement>();
        if (movement != null) movement.enabled = false;

        yield return null;
    }
}
