using Unity.VisualScripting;
using UnityEngine;

public class DestoryOnContact: MonoBehaviour
{

    void OnTriggerEnter2D (Collider2D collision)
    {
        Destroy(gameObject);
    }


}
