using Unity.VisualScripting;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    [SerializeField]
    private SpawnBullet spawnBaseAt;
    [SerializeField]
    private BulletData bulletData;
    [SerializeField] 
    private bool autoFire = true;
    private void Start()
    {
        if (autoFire)
            StartCoroutine(spawnBaseAt.CalculateRotate(bulletData));
    }
    private void OnDisable()
    {
        spawnBaseAt.StopShooting();
    }
}
