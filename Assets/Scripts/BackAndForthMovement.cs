using UnityEngine;

public class BackAndForthMovement : MonoBehaviour
{
    bool moveRight = true;

    public float horizontalSpeed = 3f;

    public float verticalSpeed = 1f;

    void Update()
    {

        if (transform.position.x > 4f)
        {

            moveRight = false;

        }
        if (transform.position.x < -4f)
        {
            moveRight = true;

        }

        float horizontal;
        if (moveRight)
        {
            horizontal = horizontalSpeed;
        }
        else
        {
            horizontal = -horizontalSpeed;
        }




        Vector3 movement = new Vector3(horizontal, -verticalSpeed, 0) * Time.deltaTime;



        transform.position += movement;
    }
}