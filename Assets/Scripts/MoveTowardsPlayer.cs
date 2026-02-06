using Unity.Mathematics;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    public float speed = 1;

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3) Vector2.down * Time.deltaTime * speed;
    }
}
