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
        Player.Instance.Health += heal;
    }
}

