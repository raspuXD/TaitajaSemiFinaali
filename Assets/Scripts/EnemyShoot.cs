using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject BulletPrefab;
    public float bulletSpeed = 10f;

    public float fireRate = 0.5f;
    private float nextFireTime = 0f;

    public Transform target; // Target that the enemy will shoot at
    public float shootingRange = 5f; // The maximum distance to shoot

    void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
        // Check if the target is within shooting range
        if (target != null && Vector2.Distance(transform.position, target.position) <= shootingRange)
        {
            // Only allow shooting if the cooldown has passed
            if (Time.time >= nextFireTime)
            {
                GameObject bullet = Instantiate(BulletPrefab, firePoint.position, firePoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.velocity = firePoint.up * bulletSpeed; // Shoot the bullet in the firePoint's up direction
                }

                nextFireTime = Time.time + fireRate;
            }
        }
    }
}
