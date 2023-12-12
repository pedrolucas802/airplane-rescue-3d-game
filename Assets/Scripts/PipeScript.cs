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
