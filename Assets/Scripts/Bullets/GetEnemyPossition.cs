using UnityEngine;

public class GetEnemyPossition : MonoBehaviour
{
    public static GetEnemyPossition Instance { get; private set; }
    private ListEnemyEntry listEnemyEntry;

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
        listEnemyEntry = GetComponentInParent<ListEnemyEntry>();
    }
    public Transform GetEnemy()
    {
        if (listEnemyEntry.EnemyEntry.Count != 0 && listEnemyEntry != null)
        {
            listEnemyEntry.EnemyEntry.RemoveAll(item => item == null);
            if (listEnemyEntry.EnemyEntry.Count >0)
            {
                return listEnemyEntry.EnemyEntry[0].transform;
            }
        }
        return null;
    }
}
