using UnityEngine;

public class EscForPause : MonoBehaviour
{
    public GameObject PauseMenu;
    private PlayerControls inputActions;

    private void Awake()
    {
        inputActions = new PlayerControls();
        inputActions.Player.Enable();
    }
    private void OnDisable()
    {
        inputActions.Player.Disable();
    }
    void Update()
    {


        if (inputActions.Player.Pause.triggered)
        {
            bool isActive = !PauseMenu.activeSelf;
            PauseMenu.SetActive(isActive);

            if (isActive)
                Time.timeScale = 0f;
            else
                Time.timeScale = 1f;
        }

        

    }
}
