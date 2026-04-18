using UnityEngine;



public class Enemy : MonoBehaviour
{
    [Header("Base Stats")]
    public float health = 50;
    public float speed = 3.0f;
    public int damage = 5;

    [Header("Knockback Settings")]
    public float knockbackForce = 5f;
}
