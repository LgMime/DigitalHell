using UnityEngine;

public abstract class BaseSkill : MonoBehaviour, ISkill
{
    public abstract SkillType Type { get; }
    public abstract BulletData BulletData { get; }

    protected int level = 0;

    public float Cooldown => BulletData.cooldown;
    public int Level => level;
    public string Name => GetType().Name;
    public bool IsActive => level > 0;
    // How many bullets are fired per timer tick? (Default: 1)
    public virtual int BurstsCount => 1;
    // Delay between bullets in the queue (Default: 0)
    public virtual float BurstDelay => 0f;

    public abstract void Attack(BulletSpawn spawner);

    public void SkillUpgrade()
    {
        level++;
        OnLevelUp();
    }
    // Это дети МОГУТ написать (что менять при апе), но не обязаны
    protected virtual void OnLevelUp() { }

}

