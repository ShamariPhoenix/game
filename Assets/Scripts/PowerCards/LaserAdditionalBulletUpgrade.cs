using UnityEngine;

public class LaserAdditionalBulletUpgrade : PowerCard
{
    public override void ApplyChoice()
    {
        player.GetComponentInChildren<Laser>().numBullets += 1;
    }
}
