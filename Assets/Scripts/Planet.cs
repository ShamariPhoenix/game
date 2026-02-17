using UnityEngine;
using TMPro;

public class Planet : MonoBehaviour
{
    public float BaseHealth;
    public ParticleSystem planetHitPS;
    private float CurrentHealth;
    private GameManager gameManager;
    private TextMeshProUGUI textMesh;
    private Damager damager;

    private void Start()
    {
        CurrentHealth = BaseHealth;
        gameManager = FindFirstObjectByType<GameManager>();
        textMesh = GetComponentInChildren<TextMeshProUGUI>();
        damager = GetComponent<Damager>();
        damager.SetDamage(1000);
        UpdateHealthText();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageableEntity damageableEntity = other.GetComponent<DamageableEntity>();
        if (damageableEntity != null)
        {
            CurrentHealth -= damageableEntity.MaxHealth;
            UpdateHealthText();
            var emitParams = new ParticleSystem.EmitParams
            {
                position = other.transform.position,
                applyShapeToPosition = true
            };
            planetHitPS.Emit(emitParams, 1);
            if (CurrentHealth <= 0)
            {
                OnHealthReachedZero();
            }
        }
    }

    private void OnHealthReachedZero()
    {
        gameManager.PlanetDestroyed();
    }

    private void UpdateHealthText()
    {
        textMesh.text = $"Health: {CurrentHealth}";
    }
}
