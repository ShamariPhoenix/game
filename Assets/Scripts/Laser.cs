using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Laser : MonoBehaviour
{
    public GameObject bulletPrefab;

    public float fireRate;

    public Transform enemyParent;

    public int numBullets { get; set; } = 1;

    private Transform playerTransform;

    private float timer = 0;



    void Start()
    {
        playerTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1 / fireRate)
        {
            shootBullet();
            timer = 0;
        }

    }

    private void shootBullet()
    {
        for (int i = 0; i < numBullets; i++)
        {

            var bullet = Instantiate(bulletPrefab);
            bullet.transform.position = playerTransform.position;
            var projectile = bullet.GetComponent<Projectile>();
            var direction = Vector2.up;

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
