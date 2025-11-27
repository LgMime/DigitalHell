using Unity.VisualScripting;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    [SerializeField]
    private BulletSpawn spawnBaseAt;
    [SerializeField]
    private BulletData bulletData;
    [SerializeField] 
    private bool autoFire = true;
    private void Start()
    {
        if (autoFire)
            StartCoroutine(spawnBaseAt.SpawnBullet(bulletData));
    }
    private void OnDisable()
    {
        spawnBaseAt.StopShooting();
    }
}
