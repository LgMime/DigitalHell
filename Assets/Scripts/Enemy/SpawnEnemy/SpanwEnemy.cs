using System.Collections;
using UnityEngine;

public class SpanwEnemy : MonoBehaviour
{
    //ToDo сделать лист врагов и спавнить старый тип врага и нововый в зависимости от времени игры
    public GameObject enemyPrefab;
    public GameObject[] spawnPoints;

    public float spawnInterval = 2f;
    private void Start()
    {
        StartCoroutine(SpawnEnemyRoutine(spawnInterval));
    }
    private IEnumerator SpawnEnemyRoutine(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            Spawnenemy();
        }
    }
    private void Spawnenemy()
    {
        var randomIndex = Random.Range(0, spawnPoints.Length);
        Vector3 spawnPos = spawnPoints[randomIndex].transform.position;
        Vector3 spawnPosZeroZ = new Vector3(spawnPos.x, spawnPos.y, 0);
        Instantiate(enemyPrefab, spawnPosZeroZ, Quaternion.identity);

    }
}
