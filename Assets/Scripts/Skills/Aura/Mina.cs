using System.Collections;
using System.Net.NetworkInformation;
using UnityEngine;

public class Mina : AbstractBaseAura
{
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public override void Activate(Transform target, float dmg, float duration, float knockback)
    {
        if (target != null)
            transform.position = target.position;
        damage = dmg;
        knockbackForce = knockback;
        gameObject.SetActive(true);  


        StopAllCoroutines();
        StartCoroutine(ExplosionTimer(duration));
    }

    public IEnumerator ExplosionTimer(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);

        Explode();

    }


    private void Explode()
    {
        if (_animator != null)
        {
            _animator.SetTrigger("Explode");
        }
        CircleCollider2D col = GetComponent<CircleCollider2D>();
        float realRadius = col.radius * transform.localScale.x;
        
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, realRadius);

       foreach (var hitCollider in hitColliders)
       {
          if (hitCollider.TryGetComponent(out IDamageable enemy))
          {
                OnHitEnemy(enemy, hitCollider.gameObject);
          }
       }
        Deactivate();
    }

    protected override void OnHitEnemy(IDamageable enemy, GameObject obj)
    {
        enemy.TakeDamage(damage);
        TryKnockback(obj);
    }
}
