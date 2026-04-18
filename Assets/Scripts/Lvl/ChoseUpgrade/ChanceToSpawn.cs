using System.Collections.Generic;
using UnityEngine;

public class ChanceToSpawn : MonoBehaviour
{
    public static ChanceToSpawn Instance { get; private set; }
    public List<RarityData> rarityDatas; // list of rarity data, which will be set in the inspector

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public RarityData CalculateChance()
    {
        int totalWeight = 0;

        // 1. chance (: Common=70 + Rare=25 + Epic=5 = 100)
        foreach (RarityData rarity in rarityDatas)
        {
            totalWeight += rarity.ChanceWeight;
        }

        // 2. here we roll a random number between 0 and the total weight (in this case, 100)
        int roll = Random.Range(0, totalWeight);

        // 3. here we iterate through the rarity data and check if the rolled number is less than the chance weight of the current rarity — if it is, we return that rarity
        foreach (RarityData rarity in rarityDatas)
        {
            if (roll < rarity.ChanceWeight)
            {
                return rarity;
            }
            else
            {
                roll -= rarity.ChanceWeight;
            }
        }
        return null; 
    }
}