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
                damageable.TakeDamage(damage);
            }
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            IDamageable damageable = other.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(damage);
            }
        }
    }
    public override void Activate(Transform transform, float dmg, float duration)
    {
        base.Activate(transform, dmg, duration);
    }

}
