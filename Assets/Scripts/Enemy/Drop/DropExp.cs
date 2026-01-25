using UnityEngine;

public class DropExp : MonoBehaviour
{
    public GameObject ExpPrefab;
    private EnemyHealth enemyDie;
    private void Start()
    {
        enemyDie = GetComponent<EnemyHealth>();
        enemyDie.OnDeath += Drop;
    }

    public void Drop()
    {
        Instantiate(ExpPrefab, transform.position, Quaternion.identity);
    }
}
