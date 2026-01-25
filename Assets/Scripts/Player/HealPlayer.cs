using UnityEngine;


public class HealPlayer : MonoBehaviour
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
        if (Player.Instance.Health + heal > Player.Instance.MaxHealth)
        {
            Player.Instance.Health = Player.Instance.MaxHealth;
            return;
        }
        else
            Player.Instance.Health += heal;
    }
}

