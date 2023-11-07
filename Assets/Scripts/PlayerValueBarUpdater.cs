using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerValueBarUpdater : MonoBehaviour
{
    public Slider playerValueBar; // Reference to the Slider component on the UI Slider.
    public BulletSpawner bulletSpawner; // Reference to the BulletSpawner script.

    void Start()
    {
        // Initialize the Slider component.
        playerValueBar = GetComponent<Slider>();

        // Find and reference the BulletSpawner script.
        bulletSpawner = FindObjectOfType<BulletSpawner>();
    }

    void Update()
    {
        // Check if the BulletSpawner script is referenced.
        if (bulletSpawner != null)
        {
            // Update the slider's value with the player's value from the BulletSpawner.
            playerValueBar.value = bulletSpawner.GetPlayerValue() / 10000f; // Scale to a 0-1 range.
        }
    }
}
