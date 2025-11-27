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
        Vector3 PlayerPos = Player.Instance.transform.position;
        Vector3 direction = (setEnemy.GetEnemy().position - PlayerPos).normalized;


        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
         
       
        return Quaternion.Euler(new Vector3(0f, 0f, angle + 90));
    }
}
