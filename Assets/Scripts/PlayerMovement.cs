using UnityEngine;
using System.Collections;
using UnityEditor;
using JetBrains.Annotations;


public class PlayerMovement: MonoBehaviour

{
    public float Max_X=10f;
    public float Min_X=-10f;

    public float Speed=1;

    private Vector3 Position;


    void Update()
    {
        if (transform.position.x<Max_X && transform.position.x>Min_X)
        {

        Movement();

        }


      
    }
    
    public void Movement()
    {

        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.position+=new Vector3(speed*Time.deltaTime,0,0);

        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position-=new Vector3(speed*Time.deltaTime,0,0);
        }

   }
}
