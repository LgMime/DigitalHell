using UnityEngine;

public class Resume : MonoBehaviour
{
    public GameObject PauseMenu;
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
    }
}
