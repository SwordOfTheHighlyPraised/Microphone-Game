using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10f; // Adjust the bullet speed as needed.

    public int damage = 1; // The amount of damage the bullet deals.
    public bool destroyable = true;


    void Update()
    {
        // Move the bullet to the right (adjust direction as needed).
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        // Check if the bullet is out of the screen.
        if (!IsInCameraView())
        {
            // Destroy the bullet when it leaves the screen.
            Destroy(gameObject);
        }
    }

    bool IsInCameraView()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        return (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collision is with an enemy.
        Enemy enemy = other.GetComponent<Enemy>();

        if (enemy != null)
        {
            // Deal damage to the enemy.
            enemy.TakeDamage(damage);
            if (destroyable)
            {
                // Destroy the bullet.
                Destroy(gameObject);
            }

        }
    }
}
