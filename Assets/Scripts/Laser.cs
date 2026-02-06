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
            Transform[] enemies = new Transform[enemyParent.childCount];
            for (int i = 0; i < enemyParent.childCount; i++)
            {
                enemies[i] = enemyParent.GetChild(i);
            }

            if (enemies.Length <= 0)
            {
                return;
            }

            var enemy = getNearestEnemy(enemies);
            faceTowards(enemy);

            shootBullet(enemy);
            timer = 0;
        }

    }

    private void faceTowards(Transform enemyTransform)
    {
        playerTransform.right = (enemyTransform.position - playerTransform.position).normalized;
    }


    private Transform getNearestEnemy(Transform[] enemies)
    {
        if (enemies.Length <= 0)
        {
            throw new Exception("Enemies array is length zero");
        }

        float minimumDistance = float.MaxValue;
        Transform nearestEnemy = enemies[0];
        foreach (var enemy in enemies)
        {
            float distance = Vector2.Distance(playerTransform.position, enemy.position);
            if (distance < minimumDistance)
            {
                minimumDistance = distance;
                nearestEnemy = enemy;
            }

        }
        return nearestEnemy;
    }

    private void shootBullet(Transform enemy)
    {
        for (int i = 0; i < numBullets; i++)
        {
            
            var bullet = Instantiate(bulletPrefab);
            bullet.transform.position = playerTransform.position;
            var projectile = bullet.GetComponent<Projectile>();
            var direction = (enemy.position - bullet.transform.position).normalized;

            var leftOfDirection = new Vector3(-direction.y, direction.x, 0);
            float offsetAmount = (i - (numBullets - 1) / 2.0f) * 0.2f;
            var offset = leftOfDirection * offsetAmount;
            bullet.transform.position += offset;
            bullet.transform.right = direction;

            projectile.fire(direction);

            var damager=bullet.GetComponent<Damager>();

            damager.setDamage(1);
        }
    }


}
