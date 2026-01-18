using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    [SerializeField] private BulletSpawn spawner;
    [SerializeField] private SpawnTimer spawnTimer;

    private List<BaseSkill> _allSkills;

    [SerializeField]
    private bool autoFire = true;
    private void Start()
    {
        _allSkills = GetComponentsInChildren<BaseSkill>().ToList();
        var startWeapon = _allSkills.Find(skill => skill.Type == SkillType.MainWeapon);
        if (startWeapon != null)
        {
            startWeapon.SkillUpgrade();
        }

        if (autoFire)
            spawnTimer.UpdateShooting(_allSkills, spawner);
    }
    private void OnDisable()
    {
        spawnTimer.StopShooting();
    }
}
