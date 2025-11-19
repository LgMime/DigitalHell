using UnityEngine;

public class LvlManager : MonoBehaviour
{
    public event System.Action OnLevelUp;

    public LevelConfig levelConfig;

    public int CurrentLevel = 0;
    public float ÑurrentExp = 0;

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
        ÑurrentExp += exp;
        CheckForLevelUp();     
    }
    private void CheckForLevelUp()
    {
       float neededExp = levelConfig.GetExperienceForLevel(CurrentLevel);
        if (ÑurrentExp >= neededExp)
        {
            ÑurrentExp -= neededExp;
            CurrentLevel++;
            // Optionally, you can add logic here to handle max level reached
            neededExp = levelConfig.GetExperienceForLevel(CurrentLevel);
            OnLevelUp?.Invoke();
            CheckForLevelUp(); // Check again in case of multiple level ups
        }
    }
}
