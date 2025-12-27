using UnityEngine;

public class OpenSettings : MonoBehaviour
{
    public GameObject settingsMenu;
    public void OpenSettingsPanel()
    {
        settingsMenu.SetActive(true);
    }
}
