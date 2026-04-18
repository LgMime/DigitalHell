using System.Collections.Generic;
using UnityEngine;


public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;
    public GameObject parentObject;

    [System.Serializable]
    public class Pool
    {
        public GameObject parentObj;
        public string name;
        public GameObject prefab;
        public int size;
    }
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Awake()
    {
        

        Instance = this;
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                // Ensure pool.parentObj is set and parented under the global parentObject
                if (pool.parentObj == null)
                {
                    pool.parentObj = parentObject;
                }
                else
                {
                    pool.parentObj.transform.SetParent(parentObject.transform);
                }

                GameObject obj = Instantiate(pool.prefab, pool.parentObj.transform);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            string key = pool.prefab.name;
            if (!poolDictionary.ContainsKey(key))
            {
                poolDictionary.Add(key, objectPool);

            }
        }
    }


    public GameObject SpawnFromPool(string poolName, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(poolName))
        {
            Debug.LogWarning("Pool with name " + poolName + " doesn't exist.");
            return null;
        }
        GameObject objectToSpawn = poolDictionary[poolName].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        poolDictionary[poolName].Enqueue(objectToSpawn);
        return objectToSpawn;
    }
}

