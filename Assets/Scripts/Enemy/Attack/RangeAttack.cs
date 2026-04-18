using UnityEngine;

public class RangeAttack : ProjectileBase
{

    // Implement the abstract handler from ProjectileBase
 
    protected override void OnHitEnemy(IDamageable target, GameObject obj)
    {
        if (obj == owner) return;
        TryKnockback(obj);
        target.TakeDamage(damage);
        Deactivate();
    }
    
}
