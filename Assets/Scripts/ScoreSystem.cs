using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private string mainMenuSceneName; // Renamed to avoid confusion

    public TextMeshProUGUI scoreText;
    private int score = 0;
    private bool gameEnded = false;
    private float timerDuration = 540f; // 3 minutes in seconds

   private void Update()
    {
        timerDuration -= Time.deltaTime;

        if (timerDuration < 2)
        {
            GameOver();
        }
        
        UpdateScoreText();

        if (score > 5)
        {
            WinGame();
        }
        
    }

    public void UpdateScore(int addition)
    {

        score= score + addition;
        Debug.Log("Score: "+ score);

    }

    private void UpdateScoreText()
    {
        int minutes = Mathf.FloorToInt(timerDuration / 60f);
        int seconds = Mathf.FloorToInt(timerDuration % 60f);

        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);

        scoreText.text = "Time:" + timeString + " / Score: " + score;
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
        scoreText.text = "Time Out!";
        gameEnded = true;

        StartCoroutine(ReloadScene(0.5f));
    }

    private void WinGame()
    {
        Debug.Log("You Win!");
        scoreText.text = "You Win!";
        gameEnded = true;

        StartCoroutine(ReloadSceneMainMenu(2.5f));

    }

    private void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    private void Start()
    {
        InvokeRepeating("UpdateScoreText", 1.5f, 1.5f); // Invoke UpdateScore every second
    }

    IEnumerator ReloadScene(float delay)
    {
        // Wait for the specified duration
        yield return new WaitForSeconds(delay);

        // Reload the current scene
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    IEnumerator ReloadSceneMainMenu(float delay)
{
    // Wait for the specified duration
    yield return new WaitForSeconds(delay);

    // Reload the main menu scene
    SceneManager.LoadScene(mainMenuSceneName);
}
}