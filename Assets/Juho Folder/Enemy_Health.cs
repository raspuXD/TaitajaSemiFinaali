using System.Collections;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public int health = 100;  // Initial health of the enemy
    public GameObject theCoinPrefab;
    public Transform spawnPoint1, spawnPoint2, spawnPoint3;

    [SerializeField] private SpriteRenderer spriteRenderer; // Assign in Inspector
    [SerializeField] private float hitEffectDuration = 0.5f; // Effect time
    [SerializeField] private float maxHitEffect = 1.0f; // Max blend value

    private Material material;
    private Coroutine hitEffectCoroutine;

    private void Start()
    {
        if (spriteRenderer != null)
        {
            // Get a material instance to avoid modifying the shared material
            material = spriteRenderer.material;
        }
    }

    public void TakeDamage(int Damage)
    {
        health -= Damage;

        // Apply hit effect when taking damage
        TakeHit();

        if (health <= 0)
        {
            Die();
        }
    }

    private void TakeHit()
    {
        if (hitEffectCoroutine != null)
        {
            StopCoroutine(hitEffectCoroutine);
        }
        hitEffectCoroutine = StartCoroutine(ApplyHitEffect());
    }

    private IEnumerator ApplyHitEffect()
    {
        float elapsedTime = 0f;
        material.SetFloat("_HitEffectBlend", maxHitEffect);

        // Gradually fade the effect
        while (elapsedTime < hitEffectDuration)
        {
            elapsedTime += Time.deltaTime;
            float blendValue = Mathf.Lerp(maxHitEffect, 0f, elapsedTime / hitEffectDuration);
            material.SetFloat("_HitEffectBlend", blendValue);
            yield return null;
        }

        // Ensure it fully resets
        material.SetFloat("_HitEffectBlend", 0f);
        hitEffectCoroutine = null;
    }

    private void Die()
    {
        float randomChance = Random.Range(0f, 1f); // Generate a random number between 0 and 1

        if (randomChance <= 0.5f) // 50% chance
        {
            Instantiate(theCoinPrefab, spawnPoint1.position, Quaternion.identity);
        }
        else if (randomChance <= 0.75f) // 25% chance
        {
            Instantiate(theCoinPrefab, spawnPoint2.position, Quaternion.identity);
        }
        else if (randomChance <= 0.85f) // 10% chance
        {
            Instantiate(theCoinPrefab, spawnPoint3.position, Quaternion.identity);
        }
        // No coin spawn for remaining 15%

        Destroy(gameObject);
    }
}
