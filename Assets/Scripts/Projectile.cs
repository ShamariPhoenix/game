using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 1;

    private Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
    
    public void fire(Vector3 direction)
    {
        this.direction = direction;
    }
}
