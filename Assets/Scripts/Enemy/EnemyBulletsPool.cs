using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class EnemyBulletsPool : MonoBehaviour
{

    public GameObject parentObject;

    public class Pool
    {
        public GameObject _bulletPrefab;
        public int size;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    private void Awake()
    { 
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool._bulletPrefab, parentObject.transform);
                objectPool.Enqueue(obj);



            }

        }

    }
}
