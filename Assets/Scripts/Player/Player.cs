

using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; } // Статическая переменная (ссылка на единственный экземпляр) 

    //public Vector3 CurrentPos;
    


    [Header("Stats")]
    public int Health = 100;
    public int MaxHealth = 250;
    public float AttackSpeed = 1.0f;
    public float Range = 2.0f;
    public float ExpRange = 3.0f;
    public float MoveSpeed = 5.0f;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // Присваиваем ссылку на текущий экземпляр класса Player
        }
        else
        {
            Destroy(gameObject); // Уничтожаем дубликат, если он существует
        }
    }
}
