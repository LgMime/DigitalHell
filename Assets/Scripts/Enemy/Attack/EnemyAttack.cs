using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int damge = GetComponent<Enemy>().Damage; 
            TakeDamagePlayer.Instance.PlayerTakeDamage(damge);
        }
    }
}
