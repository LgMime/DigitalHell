using UnityEngine;


[CreateAssetMenu(fileName = "AuraData", menuName = "Game/Aura Data")]
public class AuraData : ScriptableObject
{
    public GameObject AuraPrefab;
    public int maxLvl = 10;
    public float Cooldown = 10f;
    public float Damage = 1.0f;
    public float Duration = 2f;

}
