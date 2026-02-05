using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class DamageableEntity : MonoBehaviour
{
    public int MaxHealth;

    public ParticleSystem PS;
    private int CurrentHealth;

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
        PS.transform.SetParent(null,false);
        PS.transform.position=transform.position;
        PS.Play();  
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
