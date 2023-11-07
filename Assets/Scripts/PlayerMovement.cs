using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Camera mainCamera;
    private Vector2 spriteBounds;

    void Start()
    {
        rb = GetComponent < Rigidbody2D>();
        mainCamera = Camera.main;

        // Calculate the sprite's bounds based on its renderer
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteBounds = new Vector2(spriteRenderer.bounds.extents.x, spriteRenderer.bounds.extents.y);
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized * moveSpeed;

        // Calculate the new position
        Vector3 newPosition = transform.position + new Vector3(movement.x, movement.y, 0) * Time.deltaTime;

        // Calculate the camera bounds with sprite's pivot point
        float cameraHalfWidth = mainCamera.orthographicSize * mainCamera.aspect - spriteBounds.x;
        float cameraHalfHeight = mainCamera.orthographicSize - spriteBounds.y;

        // Restrict the player within the camera bounds
        newPosition.x = Mathf.Clamp(newPosition.x, mainCamera.transform.position.x - cameraHalfWidth, mainCamera.transform.position.x + cameraHalfWidth);
        newPosition.y = Mathf.Clamp(newPosition.y, mainCamera.transform.position.y - cameraHalfHeight, mainCamera.transform.position.y + cameraHalfHeight);

        rb.velocity = movement;
        transform.position = newPosition;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            if (enemy)
            {
                Destroy(gameObject);
            }
        }
    }
}
