using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public Image healthBarImage;

    private void Update()
    {
        float currentHealth = Player.Instance.Health;
        float maxHealth = Player.Instance.MaxHealth;
        healthText.text = $"{currentHealth} / {maxHealth}";
        healthBarImage.fillAmount = currentHealth / maxHealth;
    }

}
