using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData")]
public class LevelData : ScriptableObject
{
    [System.Serializable]
    public class EnemyWave
    {
        public string waveName;
        public GameObject enemyPrefab;
        public float waveStart;
        public float waveEnd;
        public int amountPerBurst;
        public float spawnInterval;
    }
   public List<EnemyWave> enemyWaves;
}
