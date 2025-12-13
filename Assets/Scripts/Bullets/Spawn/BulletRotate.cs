using UnityEngine;

public class BulletRotate : MonoBehaviour
{

    public BulletRotate Instance {get; private set;}
    private GetEnemyPossition setEnemy;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        setEnemy = GetComponentInParent<GetEnemyPossition>();
    }
   
    public Quaternion GetRotation()
    {

        if (setEnemy == null) return Quaternion.identity;

        Transform target = setEnemy.GetEnemy();

        // 2. ВОТ ЗДЕСЬ БЫЛА ОШИБКА:
        // Если враг умер (target == null), мы не пытаемся взять его .position
        if (target == null)
        {
            // Возвращаем "нулевой" поворот (или поворот игрока), чтобы игра не ломалась
            return Quaternion.identity;
        }

        Vector3 PlayerPos = Player.Instance.transform.position;
        Vector3 direction = (setEnemy.GetEnemy().position - PlayerPos).normalized;


        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
         
       
        return Quaternion.Euler(new Vector3(0f, 0f, angle + 90));
    }
}
