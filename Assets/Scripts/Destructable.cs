using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public GameObject bulletspawnerscript;

    public int maxHealth = 1;
    private int currentHealth;

    bool canBeDestroyed = false;
    public float bulletSizeX = 8.5f;

    // Start is called before the first frame update
    void OnAwake()
    {
        currentHealth = maxHealth; // Initialize current health.
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 17.0f)
        {
            canBeDestroyed = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!canBeDestroyed) 
        { 
            return;
        }

        BulletController bullet = collision.GetComponent<BulletController>();
        if (bullet != null)
        {
            currentHealth -= bullet.damage; // Reduce the enemy's health by the bullet's damage.

            if (currentHealth <= 0)
            {
                Destroy(gameObject); // Destroy the enemy if health is depleted.
            }

            if (bulletspawnerscript.GetComponent<BulletSpawner>().bulletPrefab1.transform.localScale.x <= bulletSizeX)
            {
                Destroy(bullet.gameObject);
            }
            else
            {
                Debug.Log("Too Big to destroy");
            }
            
            
        }
    }

}
