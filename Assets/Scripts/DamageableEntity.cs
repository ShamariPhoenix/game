using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class DamageableEntity : MonoBehaviour
{
    public int MaxHealth;
    private int CurrentHealth;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        gameManager.NotifyEnemySpawned(this);
        CurrentHealth = MaxHealth;
    }

    private void ApplyDamage(int damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            OnHealthReachedZero();
        }
    }

    private void OnHealthReachedZero()
    {
        gameManager.NotifyEnemyDeath(this);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damager damager = collision.GetComponent<Damager>();
        if (damager != null)
        {
            int damage = damager.damage;
            ApplyDamage(damage);
        }
    }
}
