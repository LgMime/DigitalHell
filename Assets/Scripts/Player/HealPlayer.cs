using UnityEngine;


public class HealPlayer : BaseHealth
{
    public static HealPlayer Instance { get; private set; }
    private void Awake()
    {
        // Если место занято - просто уходим.
        if (Instance != null && Instance != this)
        {
            return;
        }
        Instance = this;
        // DontDestroyOnLoad НЕ НУЖЕН (его делает Player.cs)
    }
  
    public void Heal(int heal)
    {
        if (currentHealth + heal > maxHealth)
        {
            currentHealth = maxHealth;
            return;
        }
        else
            currentHealth += heal;
    }

}

