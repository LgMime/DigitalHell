using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTimer : MonoBehaviour
{
    public event System.Action OnShoot;


    private Dictionary<BaseSkill, Coroutine> _activeWeapon = new Dictionary<BaseSkill, Coroutine>();
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
    public void StopShooting()
    {
        foreach (var coroutine in _activeWeapon.Values)
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
            }
        }
        _activeWeapon.Clear();
    }

    public void UpdateShooting(List<BaseSkill> allSkills, BulletSpawn spawner)
    {
        foreach (var skill in allSkills)
        {
            if (_activeWeapon.ContainsKey(skill)) continue;

            Coroutine runShoot = StartCoroutine(TimeToAttack(skill, spawner));
            _activeWeapon.Add(skill, runShoot);
        }
    }

    public IEnumerator TimeToAttack(BaseSkill skill, BulletSpawn spawner)
    {
        while (true)
        {

            yield return new WaitForSeconds(skill.Cooldown);

            if (!_canShoot)
            {
                yield return new WaitUntil(() => _canShoot);
            }
            if (skill.IsActive)
            {
                for (int i = 0; i < skill.BurstsCount; i++)
                {
                    if (_canShoot)
                    {
                        skill.Attack(spawner);
                        OnShoot?.Invoke();
                    }

                    if (i < skill.BurstsCount - 1)
                        yield return new WaitForSeconds(skill.BurstDelay);

                }
            }
        }
    }
}