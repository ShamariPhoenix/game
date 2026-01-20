using UnityEngine;

public class Damager : MonoBehaviour
{
   public int damage { get; private set; }

   public int GetDamage()
    {
        return damage;
    }

   public void setDamage(int newDamage)
    {
        damage=newDamage;
    }
}
