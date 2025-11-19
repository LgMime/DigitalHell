using UnityEngine;


[CreateAssetMenu(fileName = "LevelConfig", menuName = "Game/Level Configuration")]
public class LevelConfig : ScriptableObject
{
    public float baseExperience = 100f;
    public float growthFactor = 1.15f;


    public float GetExperienceForLevel(int level)
    {
        return Mathf.RoundToInt(baseExperience * Mathf.Pow(growthFactor, level));
    }
}
