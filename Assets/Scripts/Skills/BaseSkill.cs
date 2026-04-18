using UnityEngine;

public abstract class BaseSkill : MonoBehaviour, ISkill
{
    public abstract SkillType Type { get; }

    public string Name => GetType().Name;
    protected int level = 0;
    public int Level => level;
    private bool _wasActivated = false;
    public bool IsActive => level > 0 && !_wasActivated;

    public abstract float Cooldown { get; }

    public void SkillUpgrade()
    {
        level++;
        OnLevelUp();
    }
    public abstract void Active();
    public void TryActivate()
    {
        if (IsActive)
        {
            _wasActivated = true;
            Active();
        }
    }
   
    // Это дети МОГУТ написать (что менять при апе), но не обязаны
    protected virtual void OnLevelUp() { }

}

