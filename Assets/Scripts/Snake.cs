using UnityEngine;
using UnityEngine.AI;

public class Snake : MonoBehaviour
{
    public int damageAmount = 20;
    public float wanderTime = 5f;  // Time between wander destinations
    public float wanderRange = 10f;  // Range within which the snake will wander
    private NavMeshAgent navMeshAgent;
    private float timeToNextWander;

    private void Start()
    {
        // Get the NavMeshAgent component attached to this object
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent not found on the Snake object!");
            return;
        }
        // Start wandering
        timeToNextWander = wanderTime;
    }

    private void Update()
    {
        Wander();
    }

    private void Wander()
    {
        // Decrease the time left to wander
        timeToNextWander -= Time.deltaTime;

        // If time to wander has elapsed, set a new random destination
        if (timeToNextWander <= 0f)
        {
            Vector3 randomDirection = new Vector3(Random.Range(-wanderRange, wanderRange), 0, Random.Range(-wanderRange, wanderRange));
            Vector3 destination = transform.position + randomDirection;

            // Set the NavMeshAgent destination
            if (NavMesh.SamplePosition(destination, out NavMeshHit hit, 1f, NavMesh.AllAreas))
            {
                navMeshAgent.SetDestination(hit.position);
            }

            // Reset time for next wander
            timeToNextWander = wanderTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount);
        }
    }
}
