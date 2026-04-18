using UnityEngine;

public class SpawnerAura : MonoBehaviour
{

    public void Spawn(float damage, float duration, string prefabName)
    {
       
        GameObject auraObj = ObjectPool.Instance.SpawnFromPool(prefabName, transform.position, Quaternion.identity);
        Debug.Log($"[DEBUG] Попытка спавна. Ищем в пуле имя: '{prefabName}'");

        if (auraObj == null)
        {
            Debug.LogError($"!!! ERROR !!! ObjectPool returned NULL.\n" +
                           $"It looked for a pool named: '{prefabName}'\n");
            return; // Stop execution to prevent a crash
        }
        AbstractBaseAura aura = auraObj.GetComponent<AbstractBaseAura>();

        if (aura != null)
        {
            aura.Activate(this.transform, damage, duration);
        }
        else
        {
            Debug.LogError($"На префабе {prefabName} нет скрипта Aura или AbstractBaseAura!");
        }

    }

}

