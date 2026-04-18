using UnityEngine;

public class Standartprojectile : ProjectileBase
{
    protected override void OnHitEnemy(IDamageable enemy, GameObject obj)
    {   
        TryKnockback(obj);
        enemy.TakeDamage(damage);
        Deactivate();
    }
}