using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDied : MonoBehaviour
{
    private void Update()
    {
        PlayerDie();
    }
    public void PlayerDie()
    {
        if (Player.Instance.Health <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
