using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLaser : MonoBehaviour
{
    public GameObject bulletPrefab;

    public Transform bulletOrigin;
    public float fireRate;
    public Transform enemyParent;
    public int numBullets { get; set; } = 1;

    private Transform playerTransform;
    private float timer = 0;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    void Update()
    {
        if (playerTransform == null) return;

        timer += Time.deltaTime;
        if (timer > 1 / fireRate)
        {
            shootBullet();
            timer = 0;
        }
    }

    private void shootBullet()
    {

        Vector2 direction = Vector2.down;

        for (int i = 0; i < numBullets; i++)
        {
            var bullet = Instantiate(bulletPrefab);
            bullet.transform.position = bulletOrigin.position;

            var projectile = bullet.GetComponent<Projectile>();

            var leftOfDirection = new Vector3(-direction.y, direction.x, 0);

            float offsetAmount = (i - (numBullets - 1) / 2.0f) * 0.2f;

            var offset = leftOfDirection * offsetAmount;



            bullet.transform.position += offset;

            bullet.transform.right = direction;

            projectile.fire(direction);

            var damager = bullet.GetComponent<Damager>();
            damager.SetDamage(1);
        }
    }


}