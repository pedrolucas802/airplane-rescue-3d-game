using UnityEngine;

public class HeliportScoreTracker : MonoBehaviour
{
    private bool hasScored = false; // Flag to track if the heliport has already scored

    public bool HasScored()
    {
        return hasScored;
    }

    public void SetScored(bool scored)
    {
        hasScored = scored;
    }
}
