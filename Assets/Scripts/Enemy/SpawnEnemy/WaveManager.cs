using UnityEngine;
using UnityEngine.Pool;

public class WaveManager : MonoBehaviour
{
    public LevelData currentLvl;
    private float _levelTimer = 0f;

    private float[] _spawnTimers;
    [SerializeField] private Transform _playerTransform;
    [SerializeField]private float _spawnRadius = 20f;

    private void Start()
    {
        _spawnTimers = new float[currentLvl.enemyWaves.Count];
        _playerTransform = Player.Instance.transform;
    }
    private void Update()
    {
        _levelTimer += Time.deltaTime;

        for (int i = 0; i < currentLvl.enemyWaves.Count; i++)
        {
            var wave = currentLvl.enemyWaves[i];

            if (_levelTimer >= wave.waveStart && _levelTimer <= wave.waveEnd)
            {
                _spawnTimers[i] += Time.deltaTime;
                if (_spawnTimers[i] >= wave.spawnInterval)
                {
                    SpawnEmemies(wave);
                    _spawnTimers[i] = 0f;
                }
            }
        }

    }
    private void SpawnEmemies(LevelData.EnemyWave wave)
    {
        for (int j = 0; j < wave.amountPerBurst; j++)
        {
            Vector3 pos = GetRandomPositionAroundPlayer();
            ObjectPool.Instance.SpawnFromPool(wave.enemyPrefab.name, pos, Quaternion.identity);
        }
    }

    private Vector3 GetRandomPositionAroundPlayer()
    {
        // Простая логика: спавним за экраном
        Vector2 randomDir = Random.insideUnitCircle.normalized;
        Vector3 playerPos = _playerTransform.position;// Предполагаем, спавнер на игроке
        return playerPos + (Vector3)randomDir * _spawnRadius;// Радиус 20
    }
}
