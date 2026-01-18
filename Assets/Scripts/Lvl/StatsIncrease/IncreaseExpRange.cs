using UnityEngine;

public class IncreaseExpRange : MonoBehaviour
{
    public CircleCollider2D expRange;
    public static IncreaseExpRange Instace;
    private void Awake()
    {
        Instace = this;

    }
    public void Increase(float number)
    {
        expRange.radius = Player.Instance.ExpRange += number;
    }
}

