using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Player _player;
    private PlayerControls controls;

    private void Awake()
    {
        controls = new PlayerControls();
        _player = GetComponent<Player>();

        controls.Player.Enable();
    }
    private void OnDisable()
    {
        controls.Player.Disable();
    }

    public void FixedUpdate()
    {
        Vector2 moveVector = controls.Player.Move.ReadValue<Vector2>(); // я таке понимаю что тут я взял две оси 
        Vector3 move = new Vector3(moveVector.x, moveVector.y, 0); // и преобразовал в вектор 3д
        transform.position += move * _player.speed * Time.fixedDeltaTime; // и умножил на скорость и время


    }

}

