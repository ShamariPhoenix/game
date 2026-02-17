using UnityEngine;
using TMPro;

public class Planet : MonoBehaviour
{
    public float BaseHealth;
    private float CurrentHealth;
    private GameManager gameManager;
    private TextMeshProUGUI textMesh;

    private void Start() {
        CurrentHealth = BaseHealth;
        gameManager = FindFirstObjectByType<GameManager>();
        textMesh = GetComponentInChildren<TextMeshProUGUI>();
        UpdateHealthText();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        DamageableEntity damageableEntity = other.GetComponent<DamageableEntity>();
        if(damageableEntity != null)
        {
            CurrentHealth -= damageableEntity.MaxHealth;
            UpdateHealthText();
            if(CurrentHealth <= 0)
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
