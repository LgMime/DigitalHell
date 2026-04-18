using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    [SerializeField]
    private List<BaseSkill> _allSkills;

    private void Start()
    {
        RefreshSkillList();
        ActivateAvailableSkills();
        UpgradeSkill.SkillWasUpgrade += SkillWasUpgrade;
    }
    private void RefreshSkillList()
    {
        _allSkills = GetComponentsInChildren<BaseSkill>().ToList();
    }
    private void OnDisable()
    {
        UpgradeSkill.SkillWasUpgrade -= SkillWasUpgrade;
    }
    public void ActivateAvailableSkills()
    {
        foreach (var skill in _allSkills)
        {
            skill.TryActivate();
        }
    }
    private void SkillWasUpgrade()
    {
        ActivateAvailableSkills();
    }
    //todo : make this list and activate all skills in it
    public void SkillsUpgrader(SkillType type)
    {
        var skill = _allSkills.Find(s => s.Type == type);
        skill?.SkillUpgrade();
    }
}
