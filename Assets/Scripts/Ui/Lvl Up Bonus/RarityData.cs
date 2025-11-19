using UnityEngine;

[CreateAssetMenu(fileName = "NewRarityData", menuName = "Rarity/NewRarityData")]
public class RarityData : ScriptableObject
{
    public static RarityData Instance { get; private set; }
    public int ChanceWeight;
    public GameObject RarityPrefabConsole;
    public string RarityName;
    public Color RarityColor;
}
