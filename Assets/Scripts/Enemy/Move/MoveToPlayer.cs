using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    [SerializeField]
    private Enemy enemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Player.Instance == null) return;
        transform.position = Vector3.MoveTowards(transform.position, Player.Instance.transform.position, enemy.speed * Time.deltaTime);
    }
}
