using UnityEngine;

public class SetEnemy : MonoBehaviour
{
    public static SetEnemy Instance { get; private set; }
    public GameObject bullet;
    public BulletData bulletType;


    private void Awake()
    {
        bullet = gameObject;
      
        if (Instance == null)
            Instance = this;   
        else 
            Destroy(gameObject);     
    }
    private void Start()
    {
        SetEnemyTarget();
    }
    public void SetEnemyTarget()
    {
        Vector3 pos = GetEnemyPossition.Instance.GetEnemy().position;    
        LunchAttack lunchAttack = bullet.GetComponent<LunchAttack>();
        if (lunchAttack != null)
        {
            lunchAttack.SetTaregt(pos, bulletType);
        }
    }
}
