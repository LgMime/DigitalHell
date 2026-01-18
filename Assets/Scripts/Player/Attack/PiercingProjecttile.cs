using System.Collections.Generic;
using UnityEngine;

public class PiercingProjecttile : ProjectileBase
{
    [SerializeField] private int maxPiercingCount = 3;
    private int currentPiercingCount = 0;
    protected List<int> hitEnemy = new List<int>();

    protected override void OnHitEnemy(ITakeDamageEnemy enemy, GameObject obj)
    {
        int id = obj.GetInstanceID();
        if (hitEnemy.Contains(id)) return;

       
        TryKnockback(obj);
        enemy.TakeDamage(damage);
        currentPiercingCount++;

        if (currentPiercingCount >= maxPiercingCount)
        {
            Deactivate();
        }
        else
        {
            hitEnemy.Add(id);
        }
    }
}
