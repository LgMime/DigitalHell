using UnityEngine;

public class UpgradeSkill : MonoBehaviour
{

    [SerializeField]
    private SkillType Skill;


    public void OnClick()
    {

        // 1. Просим менеджера найти скрипт, отвечающий за этот тип
        ISkill skillScript = SkillManager.Instance.GetSkillByType(Skill);

        // 2. Проверяем, нашел ли он его (не null ли?)
        if (skillScript != null)
        {
            Debug.Log("UpgradeSkill: Апгрейдим " + Skill);
            skillScript.SkillUpgrade();

            // Закрываем меню
            SpawnUpgradeMenu.Instance.CloseUpgradeMenu();
        }
        else
        {
            Debug.LogError($"UpgradeSkill: Скилл типа {Skill} не найден в SkillManager! Возможно, скрипт не висит на игроке.");
        }

    }

}

