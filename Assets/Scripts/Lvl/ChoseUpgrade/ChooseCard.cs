using UnityEngine;


public class ChooseCard : MonoBehaviour
{

    public int DamageAmount;
    public int HealthAmount;
    public int MaxHealth;
    public float AttackSpeed;
    public float Range;
    public float ExpRange;
    public float MoveSpeed;
    public void OnButtonClick()
    {
        Player.Instance.Damage += DamageAmount;
        Player.Instance.Health += HealthAmount;
        Player.Instance.MaxHealth += MaxHealth;
        Player.Instance.AttackSpeed += AttackSpeed;
        Player.Instance.Range += Range;
        Player.Instance.ExpRange += ExpRange;
        Player.Instance.MoveSpeed += MoveSpeed;
        SpawnUpgradeMenu.Instance.CloseUpgradeMenu();
    }
}

