using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using NUnit.Framework;
using System.Runtime.InteropServices.WindowsRuntime;

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
    private List<GameObject> GetAvailableCards(List<GameObject> fullList)
    {
        return fullList.Where(card => {
            var skill = card.GetComponent<BaseSkill>();
            return skill == null || skill.Level < 5;
        }).ToList();
    }
    public List<GameObject> GenerateUniqueUpgradeCards(List<GameObject> sourceList, int count)
    {
        List<GameObject> avaibale = GetAvailableCards(sourceList);
        List<GameObject> tempPool = new List<GameObject>(avaibale);
        List<GameObject> result = new List<GameObject>();
        for (int i = 0; i < count; i++)
        {
            if (tempPool.Count == 0) break;
            int randomIndex = Random.Range(0, tempPool.Count);  
            result.Add(tempPool[randomIndex]);
            tempPool.RemoveAt(randomIndex);
        }
        return result;
    }
    public void GenerateUpgradeCards()
    {
        ClearUpgradeCards();

        List<GameObject> chosenCards = new List<GameObject>();

        for (int i = 0; i < spawnpos.Count; i++)
        {
            RarityData rolledRarity = ChanceToSpawn.Instance.CalculateChance();

            List<GameObject> sourceList = GetListByRarity(rolledRarity);

            List<GameObject> available = GetAvailableCards(sourceList);

            List<GameObject> finalPool = available.Except(chosenCards).ToList();

            if (finalPool.Count > 0)
            {
                int randomIndex = Random.Range(0, finalPool.Count);
                GameObject cardPrefab = finalPool[randomIndex];

                chosenCards.Add(cardPrefab);

                GameObject spawnedCard = Instantiate(cardPrefab, spawnpos[i].transform);
                spawnedCard.transform.localPosition = Vector3.zero;
            }
            else
            {
                Debug.LogWarning($"Нет доступных карт для редкости {rolledRarity.name}. Слот {i} пуст!");
            }
        }
    }

    // Вспомогательный метод для чистоты кода
    private List<GameObject> GetListByRarity(RarityData rarity)
    {
        if (rarity == Common) return CommonList;
        if (rarity == Rare) return RareList;
        if (rarity == Epic) return EpicList;
        return CommonList; // По дефолту
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
