using System.Collections;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public abstract class BaseHealth : MonoBehaviour, IDamageable
{
    protected int maxHealth;
    protected int currentHealth;


    public int current => currentHealth;
    public int max => maxHealth;

    public event System.Action<float> OnHealthChanged;
    public event System.Action OnDeath;


    protected virtual void OnEnable()
    {
        currentHealth = maxHealth;
        NotifyHealthChanged();
    }

    public virtual void TakeDamage(float damage)
    {
        if (currentHealth <= 0) return;

        currentHealth -= (int)damage;

        OnHealthChanged?.Invoke((float)currentHealth / maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void SetMaxHealth(int newMax, bool healToFull = true)
    {
        maxHealth = newMax;
        if (healToFull)
        {
            currentHealth = maxHealth;
        }
        NotifyHealthChanged();
    }
    protected void NotifyHealthChanged()
    {
        float percent = (maxHealth > 0f ? (float)currentHealth / maxHealth : 0f);
        OnHealthChanged?.Invoke(percent);
    }
    protected virtual void Die()
    {
        OnDeath?.Invoke();
    }
}

