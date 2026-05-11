using System.Collections;
using UnityEngine;


public class PlayerHealth : BaseHealth
{
    public static PlayerHealth Instance { get; private set; }
    private SpriteRenderer spriteRenderer;
    private Animator _animator; // Link to the Animator component
    [SerializeField]private bool _isInvincible = false;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        // If the spot is occupied - just return. DO NOT DESTROY THE OBJECT.
        if (Instance != null && Instance != this)
        {
            return; 
        }

        Instance = this;
        _animator = GetComponent<Animator>();
    }
    private void Start()
    {
        PlayerStartHealth();
        currentHealth = maxHealth;
    }


    public override void TakeDamage(float damage)
    {
        if (_isInvincible)
        {
            Debug.Log("[PlayerHealth] player can't take damage ");
            return;
        }
     
        base.TakeDamage(damage);

        if (currentHealth > 0f)
            StartCoroutine(InvincibilityFrames(Player.Instance.InvincibilityDuration));
    }
    public IEnumerator InvincibilityFrames(float duration)
    {
        _isInvincible = true;
        float flashStep = duration / 3;
        // Here you can add visual feedback for invincibility, like flashing the player sprite
        for (int i = 0; i < 5; i++)
        {
            spriteRenderer.color  = new Color (0f, 1f, 1f, 0.9f); // Semi-transparent
            yield return new WaitForSeconds(flashStep);

            // Возвращаем обычный цвет
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(flashStep);
        }
        spriteRenderer.color = Color.white;
        _isInvincible = false;

    }
    public void Heal(int heal)
    {
        currentHealth += heal;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        NotifyHealthChanged();
        Debug.Log($"[HEAL] ХП восстановлено: {currentHealth}");
    }

    protected override void Die()
    {
        base.Die();
        StartCoroutine(DeathgRunTime());
    }

    private IEnumerator DeathgRunTime()
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

    public void PlayerStartHealth()
    {
        maxHealth = Player.Instance.MaxHealth;
        SetMaxHealth(maxHealth, true);
    }
}
