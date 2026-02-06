using Unity.Mathematics;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    public float speed = 1;
     private Vector3 playerPosition;
     

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 myPosition = transform.position;
        Vector3 vectorToPlayer = (playerPosition - myPosition).normalized;
        transform.position += vectorToPlayer * Time.deltaTime*speed;

        float angle = Mathf.Atan2(vectorToPlayer.y, vectorToPlayer.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);


    
    }
}
