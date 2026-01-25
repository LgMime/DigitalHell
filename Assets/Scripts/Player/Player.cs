using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; } 

    [Header("Stats")]
    public int Health = 250;
    public int MaxHealth = 250;
    public float AttackSpeed = 1.0f;
    public float Range = 2.0f;
    public float ExpRange = 3.0f;
    public float MoveSpeed = 5.0f;
    public float InvincibilityDuration = 1.0f;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // ”¡»¬¿≈“ ƒ”¡À» ¿“
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // —Œ’–¿Õﬂ≈“ Ã≈∆ƒ” —÷≈Õ¿Ã»
    }
    private void Start()
    {
        if (PlayerHealth.Instance != null)
            PlayerHealth.Instance.SetMaxHealth(MaxHealth, true);
    }
}
