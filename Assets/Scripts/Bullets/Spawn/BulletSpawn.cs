using System.Collections;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    private BulletRotate bulletRotate;

    private void Awake()
    {
        bulletRotate = GetComponent<BulletRotate>();
    }

    public void FireOneShot(BulletData data)
    {
        if (data == null || data.BulletPrefab == null)
        {
            Debug.LogError("BulletSpawn: Invalid data or missing prefab.");
            return;
        }

        // 2. First, check for an enemy (to avoid spawning a bullet unnecessarily if no enemies exist)
        Transform targetTransform = null;
        if (GetEnemyPossition.Instance != null)
        {
            targetTransform = GetEnemyPossition.Instance.GetEnemy();
        }

        // If no enemy found, exit
        if (targetTransform == null) return;

        // 3. Try to get a bullet from the pool
        string prefabName = data.BulletPrefab.name;

        GameObject bulletObj = ObjectPool.Instance.SpawnFromPool(
            prefabName,
            transform.position,
            bulletRotate.GetRotation()
        );

        // --- IMPORTANT SAFETY CHECK (Missing in previous version) ---
        if (bulletObj == null)
        {
            Debug.LogError($"!!! ERROR !!! ObjectPool returned NULL.\n" +
                           $"It looked for a pool named: '{prefabName}'\n" +
                           $"1. Check for extra spaces inside the quotes in this error.\n" +
                           $"2. Verify that ObjectPool contains a pool with this EXACT name.\n" +
                           $"3. Ensure the pool Size is large enough (try setting it to 50+).");
            return; // Stop execution to prevent a crash
        }
        // ------------------------------------------------------------

        // 4. Launch the bullet
        ProjectileBase projectile = bulletObj.GetComponent<ProjectileBase>();

        if (projectile != null)
        {
            projectile.Launch(gameObject, targetTransform.position, data.Speed, data.Damage, data.KnockbackForce);
        }
        else
        {
            Debug.LogError($"Object '{bulletObj.name}' is missing the ProjectileBase script!");
        }
    }
}