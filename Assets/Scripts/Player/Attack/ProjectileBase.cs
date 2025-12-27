using System.Collections;
using UnityEngine;

public abstract class ProjectileBase : MonoBehaviour
{
    protected float damage;      // protected - значит "дети" видят эту переменную
    protected float speed;
    protected Vector3 flightDirection;
    protected bool isLaunched = false;
    [SerializeField] protected float lifeTime = 5f;
    public virtual void Launch(Vector3 targetPos, float spd, float dmg)
    {
        flightDirection = (targetPos - transform.position).normalized;
        speed = spd;
        damage = dmg;
        isLaunched = true;

        float angle = Mathf.Atan2(flightDirection.y, flightDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        isLaunched = true;
        StartCoroutine(LifeTimeTimer());
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
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.TryGetComponent(out ITakeDamageEnemy enemy))
            {
                // Мы не знаем, что делать при ударе.
                // Мы говорим: "Сынок, мы врезались во врага, решай сам, что делать".
                OnHitEnemy(enemy, collision.gameObject);
            }
        }
    }
    protected abstract void OnHitEnemy(ITakeDamageEnemy enemy, GameObject obj);
}

