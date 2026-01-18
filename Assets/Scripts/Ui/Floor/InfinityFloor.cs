using UnityEngine;

public class InfinityFloor : MonoBehaviour
{
    public Transform target;
    public Vector2 mapSize;

   
    // Update is called once per frame
    private void LateUpdate()
    {
        if (target == null)
        {
            FindPlayer();
            return; // Если всё еще нет — выходим, двигать фон некуда
        }
        //Distance between player and floor
        Vector3 distance = target.position - transform.position;

        if (Mathf.Abs(distance.x) >= mapSize.x)
        {
            // Сдвигаем фон ровно на ширину карты в сторону игрока
            float jumpAmount = mapSize.x * Mathf.Sign(distance.x);
            transform.position += new Vector3(jumpAmount, 0, 0);
        }
        if (Mathf.Abs(distance.y) >= mapSize.y)
        {
            float jumpAmount = mapSize.y * Mathf.Sign(distance.y);
            transform.position += new Vector3(0, jumpAmount, 0);
        }

    }
    private void FindPlayer()
    {
        if (Player.Instance != null)
        {
            target = Player.Instance.transform;
        }
    }
}
