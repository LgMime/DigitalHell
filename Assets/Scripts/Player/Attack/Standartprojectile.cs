using UnityEngine;

public class Standartprojectile : ProjectileBase
{
    protected override void OnHitEnemy(ITakeDamageEnemy enemy, GameObject obj)
    {
        // 1. Наносим урон       
        
        TryKnockback(obj);
        enemy.TakeDamage(damage);
        // 2. Исчезаем
        Deactivate();
    }
}