using UnityEngine;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScoreSystem : MonoBehaviour
{
    [SerializeField]private string MainMenu;
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
            SceneManager.LoadScene(MainMenu);
            
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
        // Get the current active scene
        Scene currentScene = SceneManager.GetActiveScene();

    // Close the current scene asynchronously
        SceneManager.UnloadSceneAsync(currentScene);

    // Load the main menu scene
        SceneManager.LoadScene("MainMenu");
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
        Invoke("GameOver", 600f);
    }
}
