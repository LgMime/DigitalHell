using System.Collections.Generic;
using UnityEngine;

public class ListEnemyEntry : MonoBehaviour
{
    public List<GameObject> EnemyEntry;
    public static event System.Action<bool> HasEnemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyEntry.Add(collision.gameObject);
            if (EnemyEntry.Count == 1)
            {
                HasEnemy?.Invoke(true);
            }
        
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyEntry.Remove(collision.gameObject);
            if (EnemyEntry.Count == 0)
            {
                HasEnemy?.Invoke(false);
            }
        }
    }
}
