using UnityEngine;

[CreateAssetMenu(fileName = "EnemyProjectileData", menuName = "ScriptableObjects/EnemyProjectileData")]
public class EnemyProjectileData : ScriptableObject
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string poolName = "Projectile"; // Имя в пуле объектов
    public float speed = 10f;
    public float damage = 5f;
    public float knockbackForce = 2f;
    public float lifeTime = 5f;
}
