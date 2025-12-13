using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SkillManager: MonoBehaviour
{

    //Todo: Сделать нормальный менеджер с получением скилов по типу. 
    // дописать на работующию логику свзяаную с skilltype, тебе нужно UpgradeSkill SkillType вот єто исправить\доипсать
    public static SkillManager Instance { get; private set; }
    private List<ISkill> allSkills = new List<ISkill>();

    private Dictionary<SkillType, ISkill> skillsMap = new Dictionary<SkillType, ISkill>();

    private SpawnTimer spawnTimer;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        var skills = GetComponentsInChildren<ISkill>();
        allSkills.AddRange(skills);
        foreach (var skill in skills)
        {
            // Проверяем, нет ли дубликатов, чтобы не было ошибки
            if (!skillsMap.ContainsKey(skill.Type))
            {
                skillsMap.Add(skill.Type, skill);
                Debug.Log($"SkillManager: Зарегистрирован скилл {skill.Type}");
            }
        }
    }
    private void Start()
    {
        spawnTimer = FindFirstObjectByType<SpawnTimer>();
        if (spawnTimer != null)
        {
            spawnTimer.OnShoot += UseAllEnabledSkills;
        }
        else
        {
            Debug.LogError("SkillManager: Не нашел SpawnTimer!");
        }
    }

    public void UseAllEnabledSkills()
    {
        foreach (ISkill skill in allSkills)
        {
            if (skill.Enabled)
            {
                skill.ActivateSkill();
            }
        }
    }

    public ISkill GetSkillByType(SkillType type) 
    {
        if (skillsMap.TryGetValue(type, out ISkill skill))
        {
            return skill;
        }
        return null;
    }
    public void UnlockSkill (SkillType type)
    {
        ISkill skill = GetSkillByType(type);
        if (skill != null)
        {
           // skill.SkillUpgrade();
        }
    }

}

