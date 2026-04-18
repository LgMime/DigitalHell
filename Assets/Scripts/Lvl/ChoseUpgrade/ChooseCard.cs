using UnityEngine;


public class ChooseCard : MonoBehaviour
{

    public int HealthAmount;
    public float MaxHealth;
    public float Range;
    public float ExpRange;
    public float MoveSpeed;
    public void OnButtonClick()
    {
        Player.Instance.Health += HealthAmount;
        Player.Instance.MaxHealth += MaxHealth;
        IncreaseRange.Instace.Increase(Range);
        IncreaseExpRange.Instace.Increase(ExpRange);
        Player.Instance.MoveSpeed += MoveSpeed;
        PlayerHealth.Instance.PlayerStartHealth();
        SpawnUpgradeMenu.Instance.CloseUpgradeMenu();

    }
}

