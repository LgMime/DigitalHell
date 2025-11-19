using UnityEngine;

public class DropExp : MonoBehaviour
{
    public GameObject ExpPrefab;
    private EnemyDie enemyDie;
    private void Start()
    {
        enemyDie = GetComponent<EnemyDie>();
        enemyDie.OnDie += Drop;
    }

    public void Drop()
    {
        Instantiate(ExpPrefab, transform.position, Quaternion.identity);
    }
}
