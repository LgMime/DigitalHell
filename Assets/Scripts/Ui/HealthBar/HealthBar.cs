using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public TextMeshProUGUI _healthText;
    public Image _healthBarImage;

    private IEnumerator Start()
    {
        yield return new WaitUntil(() => PlayerHealth.Instance != null);
        PlayerHealth.Instance.OnHealthChanged += UpdateHealthUI;
        InitializeBar();
    }


    private void OnDestroy()
    {
        // 4. Обязательно отписываемся при уничтожении, иначе будут ошибки
        if (PlayerHealth.Instance != null)
            PlayerHealth.Instance.OnHealthChanged -= UpdateHealthUI;

    }

    private void InitializeBar()
    {
        // Защита от ошибки "Invalid AABB" (деление на ноль)
        float percent = (PlayerHealth.Instance.max > 0) ? (float)PlayerHealth.Instance.current / PlayerHealth.Instance.max : 0f;

        UpdateHealthUI(percent);
    }

    // Этот метод вызывается событиями  
    private void UpdateHealthUI(float percent)
    {
        _healthBarImage.fillAmount = Mathf.Clamp01(percent);
        // 1. Обновляем картинку
        // Дополнительная защита: если percent сломался (стал NaN), ставим 0
        if (_healthText != null && PlayerHealth.Instance != null)
        {
            _healthText.text =
                $"{PlayerHealth.Instance.current:0} / {PlayerHealth.Instance.max:0}";
        }

        // 2. Обновляем Текст (если он привязан в инспекторе)
        if (_healthText != null && PlayerHealth.Instance != null)
        {
            float current = PlayerHealth.Instance.current;
            float max = PlayerHealth.Instance.max;

            _healthText.text = $"{current:0} / {max:0}";
        }
    }

}
