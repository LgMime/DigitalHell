using Unity.VisualScripting;
using UnityEngine;

public abstract class AbstractBaseAura : MonoBehaviour
{
    [Header("Aura settings")]
    protected float damage;
    protected float knockbackForce;

    protected Transform target;

    public virtual void Activate(Transform followTarget, float dmg, float duration, float knockback)
    {
        target = followTarget;
        knockbackForce = knockback;
        damage = dmg;
        if (target != null)
            transform.position = target.position;
        
        gameObject.SetActive(true);
        Invoke(nameof(Deactivate), duration);
    }
    protected virtual void LateUpdate()
    {

        // If the target is set, follow it
        if (target != null)
        {
            transform.position = target.position;
        }
    }
    protected void TryKnockback(GameObject target)
    {
        if (target.TryGetComponent(out IKnockback knockback))
        {
            knockback.ApllyKnockback(knockbackForce);
        }
    }
    protected abstract void OnHitEnemy(IDamageable enemy, GameObject obj);

    public virtual void Deactivate()
    {
        CancelInvoke();
        target = null;
        gameObject.SetActive(false);
    }
  
}
