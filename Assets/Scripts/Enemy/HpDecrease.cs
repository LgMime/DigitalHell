using System;
using UnityEngine;

public class HpDecrease : MonoBehaviour, ITakeDamageEnemy
{
    [SerializeField] private Enemy _enemyStats;
    public event Action EnemyDoDie;//нельз€ статик умрут все 

    private float _currentHealth;
    private void Awake()
    {
        _enemyStats = gameObject.GetComponent<Enemy>();
    }
    private void OnEnable()
    {
        // —брасываем здоровье при спавне (дл€ Object Pool)
        if (_enemyStats != null)
        {
            _currentHealth = _enemyStats.health; // »ли _maxHealth, если оно есть в Enemy
        }
    }
    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            EnemyDoDie?.Invoke();
        }
    }
}
