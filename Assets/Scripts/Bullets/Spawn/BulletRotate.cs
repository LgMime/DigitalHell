using UnityEngine;

public class BulletRotate : MonoBehaviour
{
    private GetEnemyPossition setEnemy;

    private void Awake()
    {
        setEnemy = GetComponent<GetEnemyPossition>();
    }

    public Quaternion GetRotation()
    {
        if (setEnemy == null) return Quaternion.identity;

        Transform target = setEnemy.GetEnemy();

        // 2. HERE WAS THE ERROR:
        // If the enemy died (target == null), we must not try to access .position
        if (target == null)
        {
            // Return "zero" rotation so the game doesn't crash
            return Quaternion.identity;
        }

        Vector3 shooterPos = transform.position; // Better to take the shooter's position, not Player.Instance

        // Optimization: Use 'target.position' directly instead of calling setEnemy.GetEnemy() again
        Vector3 direction = (target.position - shooterPos).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        return Quaternion.Euler(new Vector3(0f, 0f, angle));
    }
}