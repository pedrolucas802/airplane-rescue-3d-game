using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the TextMeshProUGUI component for score display
    private int score = 0; // Current score
    private bool gameEnded = false; // Flag to indicate if the game has ended

    public void UpdateScore()
    {
        // Increment the score
        score++;

        // Update the score display
        UpdateScoreText();

        // Check if the score reaches 5
        if (score == 5 && !gameEnded)
        {
            // Call the game over function
            GameOver();
        }
    }

    private void UpdateScoreText()
    {
        // Update the score text
        scoreText.text = "Score: " + score.ToString();
    }

    private void GameOver()
    {
        // Perform game over actions
        Debug.Log("Game Over");

        // Set the gameEnded flag to true to prevent further execution of GameOver logic
        gameEnded = true;

        // Close the game
        QuitGame();
    }

    private void QuitGame()
    {
        // Quit the application
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    private void Start()
    {
        // Start a timer to call GameOver after 2 minutes
        Invoke("GameOver", 120f);
    }
}
