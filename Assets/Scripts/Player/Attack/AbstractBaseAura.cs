using Unity.VisualScripting;
using UnityEngine;

public abstract class AbstractBaseAura : MonoBehaviour
{
    [Header("Aura settings")]
    protected float damage;
    protected Transform target;

    public virtual void Activate(Transform followTarget, float dmg, float duration)
    {
        target = followTarget;
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
    public virtual void Deactivate()
    {
        CancelInvoke();
        target = null;
        gameObject.SetActive(false);
    }
  
}
