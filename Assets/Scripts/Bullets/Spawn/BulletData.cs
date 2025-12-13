using UnityEngine;


[CreateAssetMenu(fileName = "BulletData", menuName = "Game/Bullet Data")]
public class BulletData : ScriptableObject
{
    public GameObject bulletPrefab;
    public float damage;
    public float speed;
    public float cooldown;
}

