using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDied : MonoBehaviour
{
    [SerializeField] private float _delayBeforeRestart = 5f; // Время ожидания в секундах
    private bool _isDead = false; // Флаг, чтобы умереть только один раз
    private Animator _animator; // Ссылка на аниматор
    private void Awake()
    {
        // Находим аниматор (так же, как делали в скрипте Movement)
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Player.Instance.Health <= 0 && !_isDead)
        {
            StartCoroutine(DieProcess());
        }
    }
    private IEnumerator DieProcess()
    {
        _isDead = true; // Ставим флаг, что процесс пошел

        // 1. Запускаем анимацию
        if (_animator != null)
        {
            _animator.SetTrigger("DoDie");
        }

        // Совет: Тут полезно отключить скрипт движения, чтобы труп не мог ходить
        var movement = GetComponent<Movement>();
        if (movement != null) movement.enabled = false;

        // 2. Ждем указанное время (чтобы анимация успела проиграться)
        yield return new WaitForSeconds(_delayBeforeRestart);

        // 3. Загружаем сцену
        if (Player.Instance != null)
        {
            Destroy(Player.Instance.gameObject);
        }
        var expManager = FindAnyObjectByType<LvlManager>();
        if (expManager != null) Destroy(expManager.gameObject);

        SceneManager.LoadScene("GameOverScene");
    }
}
