using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the TextMeshProUGUI component for score display

    private int score = 0; // Current score

    public void UpdateScore()
    {
        // Increment the score
        score++;

        // Update the score display
        UpdateScoreText();

        // Check if the score reaches 5
        if (score >= 0)
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
        // You can add more game over logic here, such as displaying a game over screen, stopping gameplay, etc.
    }
}

