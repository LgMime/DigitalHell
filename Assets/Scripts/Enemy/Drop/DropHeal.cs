using UnityEngine;


public class DropHeal : MonoBehaviour
{
    public GameObject HealthPrefab;
    private EnemyDie enemyDie;
    [Range(0f, 1f)] public float dropChance = 0.2f;
    void Start()
    {
        enemyDie = GetComponent<EnemyDie>();
        enemyDie.OnDie += CallDrop;
    }

    public void CallDrop()
    {
        if (Random.value <= dropChance)
        {
            Vector3 spawnPosition = transform.position + Vector3.up * 0.5f;
            Instantiate(HealthPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
