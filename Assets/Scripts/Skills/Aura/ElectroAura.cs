using System;
using UnityEngine;

public class ElectroAura : AbstractAura, ISkill
{
    bool ISkill.IsActive => IsActive;
    public override SkillType Type => SkillType.ElectroAura;
    private SpawnerAura spawnerAura;
    private SpawnTimer spawnTimer;
    public void Awake()
    {
        auraData = Instantiate(auraData); //clone to avoid modifying the original ScriptableObject
        spawnerAura = GetComponentInParent<SpawnerAura>();
        spawnTimer = GetComponentInParent<SpawnTimer>();
    }

    public override void Active()
    {
        float bonus = (Level - 1) * 0.1f;
        float duration = auraData.Duration * (1 + bonus);
        float damage = auraData.Damage * (1 + bonus);
        if (spawnerAura != null)
        {
            spawnerAura.Spawn(damage, duration, auraData.AuraPrefab.name);
        }
        StartCoroutine(spawnTimer.Timer(Active, Cooldown));
    }

    protected override void OnLevelUp()
    {
        Debug.Log($"ElectroAura skill upgraded to level {level}");
        // Здесь можно добавить дополнительные эффекты при повышении уровня, если нужно
    }

}