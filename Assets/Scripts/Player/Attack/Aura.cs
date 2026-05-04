using UnityEngine;

public class Aura : AbstractBaseAura
{
  
    public void Update()
    {
        transform.Rotate(0, 0, -100 * Time.deltaTime);
    }   
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            IDamageable damageable = other.GetComponent<IDamageable>();
            if (damageable != null)
            {
                OnHitEnemy(damageable, other.gameObject);
            }
        }
    }

    public override void Activate(Transform transform, float dmg, float duration, float knockback)
    {
        base.Activate(transform, dmg, duration, knockback);
    }
    protected override void OnHitEnemy(IDamageable enemy, GameObject obj)
    {
        enemy.TakeDamage(damage);
        TryKnockback(obj);
    }
}
