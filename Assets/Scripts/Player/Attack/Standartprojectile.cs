using UnityEngine;

public class Standartprojectile : ProjectileBase
{
   protected override void OnHitEnemy(ITakeDamageEnemy enemy, GameObject obj)
    {
        enemy.TakeDamage(damage);
        Deactivate();
    }
}
