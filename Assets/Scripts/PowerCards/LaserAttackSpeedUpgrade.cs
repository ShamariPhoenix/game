using UnityEngine;

public class LaserAttackSpeedUpgrade : PowerCard
{
    public override void ApplyChoice()
    {
        player.GetComponentInChildren<Laser>().fireRate *= 1.1f;
    }
}
