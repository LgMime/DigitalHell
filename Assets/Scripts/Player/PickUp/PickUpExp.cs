using UnityEngine;

public class PickUpExp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Exp"))
        {
            LvlManager.Instance.AddExp(15);

            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Heal"))
        {
            // Обращайся к тому скрипту, который РЕАЛЬНО управляет жизнями
            PlayerHealth.Instance.Heal(5);
            Destroy(collision.gameObject);
        }
    }
}
