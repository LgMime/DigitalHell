using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, Player.Instance.transform.position, Time.fixedDeltaTime);
    }
}
