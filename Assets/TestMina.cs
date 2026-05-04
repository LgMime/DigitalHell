using UnityEngine;
using UnityEngine.InputSystem; // Добавляем этот namespace

public class TestMina : MonoBehaviour
{
    public Mina targetMina;

    void Update()
    {
        // В новой системе вместо GetKeyDown используется Keyboard.current
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Debug.Log("[TEST] Нажат пробел! Вызываю Activate вручную.");
            targetMina.Activate(transform, 10f, 2f, 1000f);
        }
    }
}