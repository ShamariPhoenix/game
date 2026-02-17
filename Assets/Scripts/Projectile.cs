using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 1;
    public float maxLifetime = 5;

    private Vector3 direction;
    private float lifetime = 0;

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        lifetime += Time.deltaTime;
        if(lifetime >= maxLifetime)
        {
            Destroy(gameObject);
        }
    }
    
    public void fire(Vector3 direction)
    {
        this.direction = direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}
