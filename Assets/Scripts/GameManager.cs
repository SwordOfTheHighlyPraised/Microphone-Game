using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance of the GameManager.
    public TextMeshProUGUI scoreText; // Reference to a TextMeshProUGUI component to display the score.

    private int playerScore = 0; // The player's score.

    private void Awake()
    {
        // Ensure there is only one GameManager instance.
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Initialize the game.
        UpdateScoreText();
    }

    public void AddScore(int score)
    {
        // Add to the player's score.
        playerScore += score;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        // Update the score displayed on the screen.
        if (scoreText != null)
        {
            scoreText.text = "Score: " + playerScore;
        }
    }
}
