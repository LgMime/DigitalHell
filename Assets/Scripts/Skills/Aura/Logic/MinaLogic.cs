using UnityEngine;

public class MinaLogic : AbstractAura, ISkill
{
    public override SkillType Type => SkillType.Mina;
    [SerializeField]
    private Transform spriteTransform;

    private SpawnTimer spawnTimer;
    private SpawnerAura spawnerAura;


    void Start()
    {
        spawnTimer = GetComponent<SpawnTimer>();
        spawnerAura = GetComponent<SpawnerAura>();
        spriteTransform = GetComponent<Transform>();
    }

    public override void Active()
    {

        if (spawnerAura != null)
        {
            spawnerAura.Spawn(auraData.Damage, auraData.Duration, auraData.AuraPrefab.name, auraData.Knockback);

            GameObject aura = GameObject.Find(auraData.AuraPrefab.name + "(Clone)");
            if (aura == null) aura = GameObject.Find(auraData.AuraPrefab.name);

            if (aura != null)
            {
                // Передаем масштаб текущего уровня скилла в префаб
                aura.transform.localScale = spriteTransform.localScale;
            }
        }
        StartCoroutine(spawnTimer.Timer(Active, Cooldown));
    }

    protected override void OnLevelUp()
    {
        if(level > 1  && level <= 5)
        {
            spriteTransform.localScale += new Vector3(0.2f, 0.2f, 0);
            auraData.Damage += 10;
            auraData.Cooldown -= 0.3f;
        }
    }
}
