
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private float _restartDelay = 2f;

    private void OnEnable()
    {
        if (_playerHealth !=null)
        {
            _playerHealth.OnDeath += HandlePlayerDeath;

        }
    }
    private void OnDisable()
    {
        if (_playerHealth !=null)
        {
            _playerHealth.OnDeath -= HandlePlayerDeath;
        }
    }

    private void HandlePlayerDeath()
    {
        StartCoroutine(RestartGameAfterDelay());
    }
    private IEnumerator RestartGameAfterDelay()
    {
        yield return new WaitForSeconds(_restartDelay);
        CleanupSingletons();
        SceneManager.LoadScene("GameOverScene");
    }

    private void CleanupSingletons()
    {
        // Если у тебя Player и LvlManager помечены как DontDestroyOnLoad,
        // их надо уничтожить вручную.
        if (Player.Instance != null) Destroy(Player.Instance.gameObject);

        var expManager = FindAnyObjectByType<LvlManager>();
        if (expManager != null) Destroy(expManager.gameObject);
    }
}

