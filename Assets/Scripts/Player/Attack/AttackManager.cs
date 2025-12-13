using Unity.VisualScripting;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    [SerializeField]
    private BulletSpawn spawnBaseAt;
    [SerializeField]
    private SpawnTimer spawnTimer;
    [SerializeField]
    private BulletData bulletData;
    [SerializeField] 
    private bool autoFire = true;
    private void Start()
    {
        if (autoFire)
            StartCoroutine(spawnTimer.StartSpawnTimer(bulletData, spawnBaseAt));
    }
    private void OnDisable()
    {
        spawnTimer.StopShooting();
    }
}
