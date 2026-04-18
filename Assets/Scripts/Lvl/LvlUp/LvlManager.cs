using UnityEngine;

public class LvlManager : MonoBehaviour
{
    public event System.Action OnLevelUp;

    public LevelConfig levelConfig;

    public int CurrentLevel = 0;
    public float CurrentExp = 0;

    public static LvlManager Instance{get; private set;}
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    

    public void AddExp(float exp)
    {
        CurrentExp += exp;
        CheckForLevelUp();     
    }
    private void CheckForLevelUp()
    {
       float neededExp = levelConfig.GetExperienceForLevel(CurrentLevel);
        if (CurrentExp >= neededExp)
        {
            CurrentExp -= neededExp;
            CurrentLevel++;
            // Optionally, you can add logic here to handle max level reached
            neededExp = levelConfig.GetExperienceForLevel(CurrentLevel);
            OnLevelUp?.Invoke();
            CheckForLevelUp(); // Check again in case of multiple level ups
            
        }
       
    }
    [ContextMenu("DEBUG: 1 lvl")]
    public void DebugAddExp()
    {
        float neededExp = levelConfig.GetExperienceForLevel(CurrentLevel);
        AddExp(neededExp);
    }
}
