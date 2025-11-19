using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    [SerializeField]
    private Image expBarImage;

    // Update is called once per frame
    void Update()
    {
       expBarImage.fillAmount = LvlManager.Instance.ÑurrentExp / LvlManager.Instance.levelConfig.GetExperienceForLevel(LvlManager.Instance.CurrentLevel);

    }
}
