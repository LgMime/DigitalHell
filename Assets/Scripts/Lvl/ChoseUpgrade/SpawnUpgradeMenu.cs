using UnityEngine;

public class SpawnUpgradeMenu : MonoBehaviour
{
    public static SpawnUpgradeMenu Instance { get; private set; }

    public GameObject UpgradeMenuPanel;
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

    private void OnEnable()
    {
        LvlManager.Instance.OnLevelUp += ShowUpgradeMenu;

    }
    private void OnDisable()
    {
        LvlManager.Instance.OnLevelUp -= ShowUpgradeMenu;
    }

    private void ShowUpgradeMenu()
    {
        UpgradeMenuPanel.SetActive(true);
        GenerateUpgrade.Instance.GenerateUpgradeCards();
        Time.timeScale = 0f;
    }
    public void CloseUpgradeMenu()
    {
        UpgradeMenuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

}
