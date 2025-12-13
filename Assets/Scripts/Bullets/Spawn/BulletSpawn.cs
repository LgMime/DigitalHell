using System.Collections;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    //!!!!!no singleton!!!!
    private BulletRotate bulletRotate;

    private void Awake()
    {
        bulletRotate = GetComponent<BulletRotate>();  
    }



    public void SpawnBullet(BulletData data)
    {
        GameObject spawnbullet = Instantiate(data.bulletPrefab, transform.position, bulletRotate.GetRotation());
        
    }

}

