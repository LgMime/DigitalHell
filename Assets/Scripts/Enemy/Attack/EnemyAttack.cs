using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.Instance.health -= GetComponent<Enemy>().Damage;
        }
    }
}
