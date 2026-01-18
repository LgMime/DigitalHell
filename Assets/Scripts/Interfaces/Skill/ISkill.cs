

public interface ISkill
{
    SkillType Type { get; }
    string Name { get; }
    bool IsActive { get; }
    void SkillUpgrade();
}

