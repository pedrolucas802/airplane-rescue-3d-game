using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManagerScript : MonoBehaviour
{
   void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        Debug.Log("Player collided with rescue");

        ScoreSystem scoreSystem = other.GetComponent<ScoreSystem>();

        if (scoreSystem != null)
        {
            scoreSystem.UpdateScore(3);
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
