using UnityEngine;
using TMPro;

public class ObjectDropper : MonoBehaviour
{
    public GameObject boxPrefab; // Prefab of the box object
    public Transform planeTransform; // Transform of the plane
    public float dropInterval = 2f; // Time interval between dropping boxes
    public KeyCode dropKey = KeyCode.F; // Hotkey to drop the box
    public float dropDistance = 1f; // Distance below the plane to drop the box

    private float lastDropTime; // Time when the last box was dropped

    private void Update()
    {
        // Check if it's time to drop a box
        if (Time.time - lastDropTime >= dropInterval)
        {
            // Check if the drop key is pressed
            if (Input.GetKeyDown(dropKey))
            {
                lastDropTime = Time.time;

                // Calculate the drop position below the plane
                //Vector3 dropPosition = planeTransform.position + planeTransform.forward * dropDistance;
                Vector3 dropPosition = planeTransform.position - planeTransform.up * dropDistance;

                // Instantiate the box object at the drop position
                GameObject box = Instantiate(boxPrefab, dropPosition, planeTransform.rotation);
            }
        }
    }
}
