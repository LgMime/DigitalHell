using System.Collections.Generic;
using UnityEngine;

public class GenerateUpgrade : MonoBehaviour
{
    public static GenerateUpgrade Instance { get; private set; }
    public List<GameObject> spawnpos;


    [Header("Settings of Rarity")]
    public RarityData Common;
    public RarityData Rare;
    public RarityData Epic;

    [Header("List Upgrade")]
    public List<GameObject> CommonList;
    public List<GameObject> RareList;
    public List<GameObject> EpicList;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GenerateUpgradeCards()
    {  
        ClearUpgradeCards();
        for (int i = 0; i < spawnpos.Count; i++)
        {
            RarityData rolledRarity = ChanceToSpawn.Instance.CalculateChance();

            List<GameObject> targetList = null;

            if (rolledRarity == Common)
            {
                targetList = CommonList;
                
            }
            else if (rolledRarity == Rare)
            {
                targetList = RareList;
            }
            else if (rolledRarity == Epic)
            {
                targetList = EpicList;
            }

            if (targetList != null && targetList.Count > 0)
            {
                int randomIndex = Random.Range(0, targetList.Count);

                GameObject cardPrefab = targetList[randomIndex];
                GameObject myParent = Instantiate(cardPrefab, spawnpos[i].transform);
                myParent.transform.localPosition = Vector3.zero;
            }
        }
    }
    public void ClearUpgradeCards()
    {
        foreach (GameObject pos in spawnpos)
        {
            foreach (Transform child in pos.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
