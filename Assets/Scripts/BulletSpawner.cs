using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab1; // Bullet for lower microphone volumes.
    public GameObject bulletPrefab2; // Bullet for higher microphone volumes.
    private MicrophoneInput microphoneInput;
    private bool isFiring = false;

    public float minBulletSize = 0.2f; // Minimum bullet size.
    public float maxBulletSize = 1.0f; // Maximum bullet size.
    public float sizeMultiplier = 5.0f; // Adjust this to control the size increase.
    public float volumeThreshold = 0.1f; // Microphone volume threshold to change bullets.

    public float switchThreshold = 0.5f; // Threshold to switch between bullet types.

    public float playerValue = 1000f; // Player's value.
    public float maxPlayerValue = 1000f; // Player's value.
    public float valueRegenerationRate = 2f; // Rate at which the player's value regenerates.
    public float bulletPrefab1PlayerValue = 15f; //bulletPrefab1 Player Value

    void Start()
    {
        microphoneInput = FindObjectOfType<MicrophoneInput>();
    }

    void Update()
    {
        // Regenerate player's value.
        playerValue = Mathf.Min(maxPlayerValue, playerValue + (valueRegenerationRate * Time.deltaTime));

        float microphoneVolume = microphoneInput.GetMicrophoneVolume();

        // Log the microphone volume.
        Debug.Log("Microphone Volume: " + microphoneVolume);
        Debug.Log("Player Value: " + playerValue);

        if (playerValue <= 0)
        {
            // Do not fire any bullets if playerValue is 0 or less.
            if (isFiring)
            {
                StopFiring();
            }
        }
        else if (microphoneVolume > volumeThreshold && playerValue >= 0)
        {
            if (!isFiring)
            {
                StartFiring(microphoneVolume);
            }
        }
        else
        {
            if (isFiring)
            {
                StopFiring();
            }
        }
    }

    void StartFiring(float microphoneVolume)
    {
        if (playerValue <= 0)
        {
            return; // Don't start firing if player value is 0 or less.
        }

        isFiring = true;
        InvokeRepeating("FireBullet", 0f, 0.1f); // Adjust the rate as needed.

        if (microphoneVolume > switchThreshold && playerValue >= maxPlayerValue/2)
        {
            SetBulletSize(bulletPrefab2, 200f);
            playerValue -= 100f;
        }
        else
        {
            if (playerValue >= bulletPrefab1PlayerValue)
            {
                SetBulletSize(bulletPrefab1, bulletPrefab1PlayerValue);
                playerValue -= bulletPrefab1PlayerValue;
            }
            else
            {
                SetBulletSize(bulletPrefab1, playerValue);
                playerValue = 0;
            }
        }
    }

    void StopFiring()
    {
        isFiring = false;
        CancelInvoke("FireBullet");
    }

    void SetBulletSize(GameObject bullet, float size)
    {
        // Set the bullet size directly.
        bullet.transform.localScale = new Vector3(size, size, 1.0f);
    }

    void FireBullet()
    {
        {
            // Choose the appropriate bullet prefab based on microphone volume and player value.
            float microphoneVolume = microphoneInput.GetMicrophoneVolume();
            if (microphoneVolume > switchThreshold && playerValue >= 100f)
            {
                Instantiate(bulletPrefab2, transform.position + Vector3.right, Quaternion.identity);
            }
            else
            {
                Instantiate(bulletPrefab1, transform.position + Vector3.right, Quaternion.identity);
            }
        }
    }

    public float GetPlayerValue()
    {
        return playerValue;
    }
}
