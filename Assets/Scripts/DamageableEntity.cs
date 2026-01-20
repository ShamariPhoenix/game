using UnityEngine;
using UnityEngine.Rendering;

public class DamageableEntity : MonoBehaviour
{
    public int MaxHealth;
    private int CurrentHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    private void ApplyDamage(int damage)
    {
        CurrentHealth -= damage;
        if(CurrentHealth <= 0)
        {
            OnHealthReachedZero();
        }
    }

    private void OnHealthReachedZero()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damager damager = collision.GetComponent<Damager>();
        if(damager != null)
        {
            int damage = damager.damage;
            ApplyDamage(damage);
        }
    }
}
