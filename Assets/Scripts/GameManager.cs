using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;

    private List<DamageableEntity> enemies = new List<DamageableEntity>();

    public void NotifyEnemySpawned(DamageableEntity enemy)
    {
        enemies.Add(enemy);
    }

    public void NotifyEnemyDeath(DamageableEntity enemy)
    {
        enemies.Remove(enemy);
        player.AddXP(enemy.MaxHealth);
    }
}
