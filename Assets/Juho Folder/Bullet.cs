using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage;

    void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the object collided with has the "EnemyCow" tag
        if (collider.CompareTag("EnemyCow"))
        {
            Enemy_Health enemyHealth = collider.GetComponent<Enemy_Health>();
            if (enemyHealth != null)
            {
                // Deal damage to the enemy
                enemyHealth.TakeDamage(Damage);
            }

            Destroy(gameObject);
        }
    }
}
