using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public abstract class ProjectileBase : MonoBehaviour
{
    [Header("Projectail settings")]
    protected float damage;      // protcted because we will use it in derived classes
    protected float knockbackForce;
    protected float speed;

    protected GameObject owner; // The entity that launched the projectile

    protected Vector3 flightDirection;
    protected bool isLaunched = false;
    [SerializeField] protected float lifeTime = 5f;

    public virtual void Launch(GameObject luncher, Vector3 targetPos, float spd, float dmg, float knockbackVal)
    {
        owner = luncher;
        flightDirection = (targetPos - transform.position).normalized;
        speed = spd;
        damage = dmg;
        knockbackForce = knockbackVal;
        isLaunched = true;

        float angle = Mathf.Atan2(flightDirection.y, flightDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        isLaunched = true;
        StartCoroutine(LifeTimeTimer());
    }

    protected void TryKnockback(GameObject target)
    {
        if (target.TryGetComponent(out IKnockback knockback))
        {
            knockback.ApllyKnockback(knockbackForce);
        }
    }

    protected void Deactivate()
    {
        isLaunched = false;
        gameObject.SetActive(false);

    }

    private IEnumerator LifeTimeTimer()
    {
        yield return new WaitForSeconds(lifeTime);
        Deactivate();
    }

    protected virtual void Update()
    {
        if (!isLaunched) return;
        transform.position += flightDirection * speed * Time.deltaTime;
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == owner)
            return;

        if (owner != null && collision.CompareTag(owner.tag))
            return;

        IDamageable damageable = collision.GetComponent<IDamageable>();

        if (damageable != null)
        {
            OnHitEnemy(damageable, collision.gameObject);
        }
    }
    protected abstract void OnHitEnemy(IDamageable enemy, GameObject obj);
}

