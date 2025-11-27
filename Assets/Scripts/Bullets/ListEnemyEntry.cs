using System.Collections.Generic;
using UnityEngine;

public class ListEnemyEntry : MonoBehaviour
{
    public List<GameObject> EnemyEntry;

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if(collision.CompareTag("Enemy"))
         {
              EnemyEntry.Add(collision.gameObject);
         }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
         if(collision.CompareTag("Enemy"))
         {
              EnemyEntry.Remove(collision.gameObject);
         }
    }
}
