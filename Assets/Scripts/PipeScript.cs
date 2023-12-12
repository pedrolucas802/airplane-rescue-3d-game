using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PipeScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        Debug.Log("Player collided with pipe");

        ScoreSystem scoreSystem = other.GetComponent<ScoreSystem>();

        if (scoreSystem != null)
        {
            scoreSystem.UpdateScore();
            Debug.Log("ScoreSystem found and score updated");
            Destroy(gameObject);
        }
        else
        {
            Debug.LogError("ScoreSystem component not found on the player.");
        }
    }
    else
    {
        Debug.Log("Not player");
    }
}
}


// using UnityEngine;
// using TMPro;

// public class PipeScript : MonoBehaviour
// {
//     public TextMeshProUGUI scoreText;
//     private int score = 0;

//     private void OnTriggerEnter(Collider other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             UpdateScore();
//             Debug.Log("Triggered Player");
//         }else{
//              Debug.Log("Triggered");
//         }
//     }

//     private void UpdateScore()
//     {
//         // Increment the score
//         score++;

    
//         scoreText.text = "Score: " + score.ToString();
//     }


// }