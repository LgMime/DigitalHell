using UnityEngine;

public abstract class BaseSkill : MonoBehaviour, ISkill
{
    public abstract SkillType Type { get; }
    protected float cooldown = 0.1f;
    protected int level = 0;
    private float lastUse;
    public string Name => gameObject.name;
    public bool Enabled => level > 0;
    public void ActivateSkill()
    {
        if (Time.time >= lastUse + cooldown)
        {
            lastUse = Time.time;
            UseSkill();
        }
    }
    public void SkillUpgrade()
    {
        level++;
        OnLevelUp();
    }
    // Это дети ОБЯЗАНЫ написать (как стрелять)
    protected abstract void UseSkill();
    // Это дети МОГУТ написать (что менять при апе), но не обязаны
    protected virtual void OnLevelUp() { }

}

