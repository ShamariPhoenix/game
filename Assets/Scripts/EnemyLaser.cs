using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLaser : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireRate;
    public Transform enemyParent;
    public int numBullets { get; set; } = 1;

    private Transform playerTransform;
    private float timer = 0;

    void Start()
    {
        // Find the player in the scene by tag (make sure your player has tag "Player")
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            playerTransform = playerObj.transform;
        }
        else
        {
            Debug.LogError("Player not found! Make sure the player has the 'Player' tag.");
        }
    }

    void Update()
    {
        if (playerTransform == null) return; // Do nothing if player not found

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
            bullet.transform.position = transform.position; // start at enemy position

            var projectile = bullet.GetComponent<Projectile>();

            // Calculate direction towards the player
            Vector2 direction = (playerTransform.position - transform.position).normalized;

            // Spread bullets if more than one
            var leftOfDirection = new Vector3(-direction.y, direction.x, 0);
            float offsetAmount = (i - (numBullets - 1) / 2.0f) * 0.2f;
            var offset = leftOfDirection * offsetAmount;
            bullet.transform.position += offset;

            // Rotate bullet to face player
            bullet.transform.right = direction;

            projectile.fire(direction);

            var damager = bullet.GetComponent<Damager>();
            damager.setDamage(1);
        }
    }
}
