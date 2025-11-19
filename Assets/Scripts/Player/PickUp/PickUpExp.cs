using UnityEngine;

public class PickUpExp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Exp"))
        {
            LvlManager.Instance.AddExp(5);

            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Heal"))
        {
            HealPlayer.Instance.Heal(20);
            Destroy(collision.gameObject);
        }
    }
}
