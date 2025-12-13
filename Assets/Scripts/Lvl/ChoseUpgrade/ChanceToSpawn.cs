using System.Collections.Generic;
using UnityEngine;

public class ChanceToSpawn : MonoBehaviour
{
    public static ChanceToSpawn Instance { get; private set; }
    public List<RarityData> rarityDatas; // Список всех возможных редкостей с их весами

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    // Главный метод расчета
    public RarityData CalculateChance()
    {
        int totalWeight = 0;

        // 1. Считаем сумму всех весов (например: Common=70 + Rare=25 + Epic=5 = 100)
        foreach (RarityData rarity in rarityDatas)
        {
            totalWeight += rarity.ChanceWeight;
        }

        // 2. Кидаем кубик от 0 до суммы весов
        int roll = Random.Range(0, totalWeight);

        // 3. Проверяем, в какой диапазон попало число
        foreach (RarityData rarity in rarityDatas)
        {
            // Если выпавшее число меньше веса текущей редкости — мы победили
            if (roll < rarity.ChanceWeight)
            {
                return rarity;
            }
            // Иначе вычитаем вес текущей редкости и идем к следующей
            // (это сдвигает диапазон проверки)
            else
            {
                roll -= rarity.ChanceWeight;
            }
        }
        return null; // На случай ошибки
    }
}