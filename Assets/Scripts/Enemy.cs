using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 3; // Maximum health for the enemy.
    private int currentHealth; // Current health of the enemy.
    public int scoreValue = 10; // The score awarded to the player when the enemy is defeated.


    public GameObject explosionEffect; // Optional explosion effect prefab.

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        // Implement your enemy movement logic here.
        // For example, move the enemy left to right.

        // Check if the enemy's health has reached 0 or less.
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Player collision logic here (e.g., decrease lives and reset position).
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Optionally, instantiate an explosion effect.
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }
        // Award score to the player.
        GameManager.Instance.AddScore(scoreValue);

        // Destroy the enemy game object.
        Destroy(gameObject);
    }
}
