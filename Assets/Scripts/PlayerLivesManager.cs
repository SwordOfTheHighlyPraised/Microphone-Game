using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLivesManager : MonoBehaviour
{
    public int maxLives = 3; // The maximum number of lives.
    public GameObject player; // Reference to the player GameObject.
    public Transform spawnPoint; // Reference to the player's spawn point.
    public Image[] lifeImages; // Array of UI images to represent lives.

    private int currentLives;

    private void Start()
    {
        currentLives = maxLives;
        UpdateLifeUI();
    }

    public void LoseLife()
    {
        if (currentLives > 0)
        {
            currentLives--;
            UpdateLifeUI();
            ResetPlayerPosition();
        }

        if (currentLives <= 0)
        {
            EndGame();
        }
    }

    private void ResetPlayerPosition()
    {
        player.transform.position = spawnPoint.position;
    }

    private void UpdateLifeUI()
    {
        for (int i = 0; i < lifeImages.Length; i++)
        {
            if (i < currentLives)
            {
                lifeImages[i].enabled = true; // Enable the image to represent a remaining life.
            }
            else
            {
                lifeImages[i].enabled = false; // Disable the image to represent a lost life.
            }
        }
    }

    private void EndGame()
    {
        // Implement game over logic here.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
