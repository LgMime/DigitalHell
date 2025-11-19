using UnityEngine;

public class TakeDamagePlayer : MonoBehaviour
{
    public static TakeDamagePlayer Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlayerTakeDamage(int damage)
    {
        Player.Instance.Health -= damage;
    }

}

