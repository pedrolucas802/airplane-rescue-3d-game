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
    private float timerDuration = 180f; // 3 minutes in seconds

    private void Update()
    {
    
            timerDuration -= Time.deltaTime;
Debug.Log("timerDuration");
Debug.Log(timerDuration);
            if (timerDuration < 2)
            {
                GameOver();
            }else{
                UpdateScoreText();
            }


            if (score > 5)
            {
                WinGame();
            }else{
                UpdateScoreText();
            }

        
    }

    public void UpdateScore()
    {
        if (!gameEnded) // Check if the game hasn't ended yet
        {
            score++;
            Debug.Log("score: " + score);
            Debug.Log("gameEnded: " + gameEnded);
        }
    }

    private void UpdateScoreText()
    {
        int minutes = Mathf.FloorToInt(timerDuration / 60f);
        int seconds = Mathf.FloorToInt(timerDuration % 60f);

        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);

        scoreText.text = "Time:" + timeString + "/ Score: " + score.ToString();
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

        StartCoroutine(ReloadScene(5f));
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
}