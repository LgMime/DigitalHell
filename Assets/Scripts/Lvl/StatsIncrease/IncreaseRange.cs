using UnityEngine;

public class IncreaseRange : MonoBehaviour
{

    public CircleCollider2D range;
    public static IncreaseRange Instace;
    private void Awake()
    {
        Instace = this;
        
    }
    public void Increase(float number)
    {

        range.radius = Player.Instance.Range += number;
    }
}

