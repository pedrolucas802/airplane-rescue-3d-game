using UnityEngine;

public class NPC : MonoBehaviour
{
    private bool isColliding = false;
    private float timer = 0f;
    private float destroyDelay = 5f;

    private void Update()
    {
        if (isColliding)
        {
            timer += Time.deltaTime;

            if (timer >= destroyDelay)
            {
                DestroyObjects();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has a specific tag
        if (other.CompareTag("aircraft"))
        {
            isColliding = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the colliding object has a specific tag
        if (other.CompareTag("aircraft"))
        {
            isColliding = false;
            timer = 0f;
        }
    }
    private void DestroyObjects()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("npc1");

        foreach (GameObject obj in objectsWithTag)
        {
            Destroy(obj);
        }
    }
}
