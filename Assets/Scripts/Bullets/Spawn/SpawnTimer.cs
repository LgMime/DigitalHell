using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTimer : MonoBehaviour
{
    private bool _canShoot = false;

    private void OnEnable()
    {
        ListEnemyEntry.HasEnemy += HandleEnemyState;
    }
    private void OnDisable()
    {
        ListEnemyEntry.HasEnemy -= HandleEnemyState;
    }
    private void HandleEnemyState(bool hasEnemies)
    {
        _canShoot = hasEnemies;
    }

    public IEnumerator Timer(Action callback, float duration)
    {
        yield return new WaitForSeconds(duration);
        callback?.Invoke();

    }
}