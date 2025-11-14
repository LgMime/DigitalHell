

using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; } // Статическая переменная (ссылка на единственный экземпляр) 
    public Vector3 currentPos;
    public int health = 100;
    public float speed = 5.0f;
    public int Damage = 10;
    public int Exp = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // Присваиваем ссылку на текущий экземпляр класса Player
            DontDestroyOnLoad(gameObject); // Опционально: сохраняем объект при загрузке новых сцен
        }
        else
        {
            Destroy(gameObject); // Уничтожаем дубликат, если он существует
        }
    }
}
