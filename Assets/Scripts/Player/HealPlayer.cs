using UnityEngine;


public class HealPlayer : MonoBehaviour
{
    public static HealPlayer Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
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

