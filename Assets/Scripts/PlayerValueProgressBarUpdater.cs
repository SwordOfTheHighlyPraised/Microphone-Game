using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerValueProgressBarUpdater : MonoBehaviour
{
    public Image playerValueProgressBar; // Reference to the Image component on the UI Image.
    public BulletSpawner bulletSpawner; // Reference to the BulletSpawner script.

    private float prevPlayerValue; // Store the previous player value.

    void Start()
    {
        // Initialize the Image component.
        playerValueProgressBar = GetComponent<Image>();

        // Find and reference the BulletSpawner script.
        bulletSpawner = FindObjectOfType<BulletSpawner>();

        // Initialize prevPlayerValue with the initial player value.
        prevPlayerValue = bulletSpawner.GetPlayerValue();
    }

    void Update()
    {
        // Check if the BulletSpawner script is referenced.
        if (bulletSpawner != null)
        {
            // Get the current player value.
            float currentPlayerValue = bulletSpawner.GetPlayerValue();

            // Update the Image's fill amount based on the change in player value.
            float playerValueChange = prevPlayerValue - currentPlayerValue;
            playerValueProgressBar.fillAmount -= playerValueChange / 100f; // Scale to a 0-1 range.

            // Update the previous player value for the next frame.
            prevPlayerValue = currentPlayerValue;
        }
    }
}
