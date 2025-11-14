using UnityEngine;

public class PickUpExp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Exp"))
        {
            Player.Instance.Exp += 10;

            Destroy(collision.gameObject);
        }
    }
}
