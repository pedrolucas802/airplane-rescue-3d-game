using UnityEngine;
using TMPro;

public class BoxScoreTrigger : MonoBehaviour
{
    public ScoreSystem scoreSystem; // Reference to the ScoreSystem script

    //private bool hasScored = false; // Flag to track if the box has already scored

    private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Heliport"))
    {
        HeliportScoreTracker heliport = other.GetComponent<HeliportScoreTracker>();

        if (heliport != null && !heliport.HasScored())
        {
            // Increment the score by 1
            scoreSystem.UpdateScore(1);

            // Set the heliport as scored
            heliport.SetScored(true);
        }
    }
}

}
