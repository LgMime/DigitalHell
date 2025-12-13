

public interface ISkill
{
    SkillType Type { get; }
    string Name { get; }
    bool Enabled { get; }
    void ActivateSkill();
    void SkillUpgrade();
}

