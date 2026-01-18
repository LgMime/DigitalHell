using UnityEngine;


[CreateAssetMenu(fileName = "BulletData", menuName = "Game/Bullet Data")]
public class BulletData : ScriptableObject
{
    public GameObject BulletPrefab;
    public int MaxLevel = 5;
    public float Damage;
    public float Speed;
    public float cooldown;
    public float KnockbackForce;
}

