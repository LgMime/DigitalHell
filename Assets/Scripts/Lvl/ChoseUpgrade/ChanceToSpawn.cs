using System.Collections.Generic;
using UnityEngine;

public class ChanceToSpawn : MonoBehaviour
{
    public  static ChanceToSpawn Instance { get; private set; }

    public List<RarityData> rarityDatas;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    public RarityData CalculateChance()
    {
        int totalWeight = 0;
        foreach (RarityData rarity in rarityDatas)
        {
            totalWeight += rarity.ChanceWeight;
        }

        int roll = Random.Range(0, totalWeight);
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
