using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Transform target;

    public int health;
    public float knockbackForce = 5f;

    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        ApplyKnockback(transform, target.transform);
    }

    public void ApplyKnockback(Transform enemyTransform, Transform playerTransform)
    {
        // Calculate the direction from the enemy to the player
        Vector3 knockbackDirection = (enemyTransform.position - playerTransform.position).normalized;

        // Apply the knockback force to the enemy
        Rigidbody2D enemyRigidbody = enemyTransform.GetComponent<Rigidbody2D>();
        if (enemyRigidbody != null)
        {
            enemyRigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
        }
    }
}
