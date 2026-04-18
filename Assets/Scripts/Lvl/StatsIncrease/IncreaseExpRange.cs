using UnityEngine;

public class IncreaseExpRange : MonoBehaviour
{
    public CircleCollider2D expRange;
    public static IncreaseExpRange Instace;
    private void Awake()
    {
        expRange = GetComponent<CircleCollider2D>();
        Instace = this;

    }
    public void Increase(float number)
    {
        expRange.radius = Player.Instance.ExpRange += number;
    }
}

