using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public ParticleSystem deathPS;

    private List<DamageableEntity> enemies = new List<DamageableEntity>();

    public void NotifyEnemySpawned(DamageableEntity enemy)
    {
        enemies.Add(enemy);
    }

    public void NotifyEnemyDeath(DamageableEntity enemy)
    {
        enemies.Remove(enemy);
        player.AddXP(enemy.MaxHealth);

        var emitParams = new ParticleSystem.EmitParams
        {
            position = enemy.transform.position,
            applyShapeToPosition = true
        };
        deathPS.Emit(emitParams, 50);
    }

    public void PlanetDestroyed()
    {
        Debug.Log("Game Over");
    }
}
