using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public int numberOfEnemies = 5; // Number of enemies in the group.
    public float spacing = 1f; // Spacing between enemies in the group.
    public float speed = 2f;
    public float amplitude = 1f;

    private Vector3[] startPositions;
    private Transform[] enemies;

    void Start()
    {
        enemies = new Transform[numberOfEnemies];
        startPositions = new Vector3[numberOfEnemies];

        // Create and initialize each enemy in the group.
        for (int i = 0; i < numberOfEnemies; i++)
        {
            GameObject enemy = Instantiate(gameObject, transform.position + Vector3.right * i * spacing, Quaternion.identity);
            enemies[i] = enemy.transform;
            startPositions[i] = enemy.transform.position;
        }
    }

    void Update()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            // Move each enemy in a sine wave pattern.
            float horizontalMovement = Mathf.Sin((Time.time + i * spacing) * speed) * amplitude;
            Vector3 newPosition = startPositions[i] + new Vector3(horizontalMovement, -((Time.time + i * spacing) * speed), 0);
            enemies[i].position = newPosition;
        }
    }

    // Add collision logic for when the enemies are hit by a bullet.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(gameObject); // Destroy the enemy group when any of its members are hit by a bullet.
        }
    }
}
