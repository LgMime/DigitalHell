using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SkillManager: MonoBehaviour
{

    //Todo: Сделать нормальный менеджер с получением скилов по типу. 
    // дописать на работующию логику свзяаную с skilltype, тебе нужно UpgradeSkill SkillType вот єто исправить\доипсать
    public static SkillManager Instance { get; private set; }

    private Dictionary<SkillType, ISkill> skillsMap = new Dictionary<SkillType, ISkill>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        var skills = GetComponentsInChildren<ISkill>();

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

    public ISkill GetSkillByType(SkillType type) 
    {
        if (skillsMap.TryGetValue(type, out ISkill skill))
        {
            return skill;
        }
        return null;
    }
}

