using UnityEngine;

public class Movement : MonoBehaviour
{
    private Player _player;
    private PlayerControls _controls;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private void Awake()
    {
        _controls = new PlayerControls();
        _player = GetComponent<Player>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponentInChildren<Animator>();

        _controls.Player.Enable();
    }
    private void OnEnable() // Лучше использовать OnEnable вместо Awake для включения контролов
    {
        _controls.Player.Enable();
    }

    private void OnDisable()
    {
        _controls.Player.Disable();
    }

    public void FixedUpdate()
    {
        // 1. Читаем ввод
        Vector2 moveVector = _controls.Player.Move.ReadValue<Vector2>();

        // --- ЛОГИКА АНИМАЦИИ (Делаем ВСЕГДА) ---
        // Обновляем скорость в аниматоре, даже если она 0
        float currentRealSpeed = moveVector.magnitude * _player.MoveSpeed;
        if (_animator != null)
        {
            _animator.SetFloat("Speed", Mathf.Abs(currentRealSpeed));
        }

        // Поворот спрайта (только если есть ввод)
        if (moveVector.x != 0)
        {
            HandleSpriteFlip(moveVector.x);
        }

        // --- ЛОГИКА ДВИЖЕНИЯ ---
        // Если движения нет, выходим, чтобы не грузить физику
        if (moveVector == Vector2.zero) return;

        Vector3 move = new Vector3(moveVector.x, moveVector.y, 0);
        transform.position += move * _player.MoveSpeed * Time.fixedDeltaTime;
    }

    private void HandleSpriteFlip(float moveX)
    {
        // Используем закэшированную переменную _spriteRenderer вместо GetComponent
        if (moveX < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (moveX > 0)
        {
            _spriteRenderer.flipX = false;
        }
    }
}

