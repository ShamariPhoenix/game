using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireRate;

    public Transform enemyParent;

    private Transform playerTransform;

    private float timer = 0;



    void Start()
    {

        playerTransform = transform;




    }

    // Update is called once per frame
    void Update()
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

        timer += Time.deltaTime;
        if (timer > 1 / fireRate)
        {
            shootBullet(enemy);
            timer = 0;
        }

    }

    private void faceTowards(Transform enemyTransform)
    {
        playerTransform.right = enemyTransform.position - playerTransform.position;
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
        var bullet = Instantiate(bulletPrefab);
        bullet.transform.position = playerTransform.position;
        var projectile = bullet.GetComponent<Projectile>();
        var direction = (enemy.position - bullet.transform.position).normalized;
        projectile.fire(direction);

        var damager=bullet.GetComponent<Damager>();

        damager.setDamage(1);
    }


}
