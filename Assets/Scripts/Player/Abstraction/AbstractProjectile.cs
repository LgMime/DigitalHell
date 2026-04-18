public abstract class AbstractProjectile: BaseSkill
{
    public abstract BulletData BulletData { get; }
    public override float Cooldown => BulletData.cooldown;

    public virtual int BurstsCount => 1;

    public virtual float BurstDelay => 0f;

    public override void Active()
    {

    }
}

