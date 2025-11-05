using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxLife = 1;

    public void inflictDamage(int damage)
    {
        maxLife -= damage;
        if (maxLife <= 0)
        {
            maxLife = 0;
            destroyPlayer();
        }
    }
    
    private void destroyPlayer()
    {
        Debug.Log("YOU LOSE");
    }
}
