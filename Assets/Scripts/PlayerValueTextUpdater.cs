using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerValueTextUpdater : MonoBehaviour
{
    public TextMeshProUGUI playerValueText; // Reference to the TextMeshPro component on the TextMeshPro object.
    public BulletSpawner bulletSpawner; // Reference to the BulletSpawner script.

    void Start()
    {
        // Initialize the TextMeshPro component.
        playerValueText = GetComponent<TextMeshProUGUI>();

        // Find and reference the BulletSpawner script.
        bulletSpawner = FindObjectOfType<BulletSpawner>();
    }

    void Update()
    {
        // Check if the BulletSpawner script is referenced.
        if (bulletSpawner != null)
        {
            // Update the TextMeshPro with the player's value from the BulletSpawner.
            playerValueText.text = "Player Value: " + bulletSpawner.GetPlayerValue().ToString("F0");
        }
    }
}
