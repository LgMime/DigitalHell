using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; } 

    [Header("Stats")]
    public int Health = 15;
    public float MaxHealth = 15;
    public float Range = 2.0f;
    public float ExpRange = 3.0f;
    public float MoveSpeed = 5.0f;
    public float InvincibilityDuration = 1.0f;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Destroy the duplicate instance
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); // Optional: Keep the player object across scenes
    }
}
