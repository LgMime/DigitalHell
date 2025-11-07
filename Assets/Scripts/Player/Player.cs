

using UnityEngine;

public class Player: MonoBehaviour
{
    public static Player Instance { get; private set; } // Статическая переменная (ссылка на единственный экземпляр) 
    public int health { get; set; } = 100;
    public float speed { get; set; } = 5.0f;
    public int Damage { get; set; } = 10;
}
