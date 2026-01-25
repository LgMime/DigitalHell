using System.Collections;
using UnityEngine;

public abstract class ProjectileBase : MonoBehaviour
{
    [Header("Projectail settings")]
    protected float damage;      // protcted because we will use it in derived classes
    protected float knockbackForce;
    protected float speed;

    protected Vector3 flightDirection;
    protected bool isLaunched = false;
    [SerializeField] protected float lifeTime = 5f;
    public virtual void Launch(Vector3 targetPos, float spd, float dmg, float knockbackVal)
    {
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
        // При выключении объекта Unity сама остановит корутину LifeTimeTimer
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
        IDamageable damageable = collision.GetComponent<IDamageable>();
        if(damageable != null)
        {
            OnHitEnemy(damageable, collision.gameObject);
        }
    }
    protected abstract void OnHitEnemy(IDamageable enemy, GameObject obj);
}

