using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    [HideInInspector] public InputActions inputActions; // Corrected typo and added missing semicolon

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        inputActions = new InputActions(); // Corrected typo
    }

    private void OnEnable() // Corrected method name
    {
        inputActions.Enable(); // Corrected typo
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
}