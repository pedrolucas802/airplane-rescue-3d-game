using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class AirplaneController : MonoBehaviour
{
    [SerializeField]
    float rollControlSensitivity = 0.2f;
    [SerializeField]
    float pitchControlSensitivity = 0.2f;
    [SerializeField]
    float yawControlSensitivity = 0.2f;
    [SerializeField]
    float thrustControlSensitivity = 0.01f;
    [SerializeField]
    float flapControlSensitivity = 0.15f;
    [SerializeField] TextMeshProUGUI hud;


    float pitch;
    float yaw;
    float roll;
    float flap;
     Rigidbody rb;

    float thrustPercent;
    bool brake = false;

    AircraftPhysics aircraftPhysics;
    Rotator propeller;

    private void Start()
    {
        aircraftPhysics = GetComponent<AircraftPhysics>();
        propeller = FindObjectOfType<Rotator>();
        SetThrust(0);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        UpdateHUD();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("MainMenu");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

        // Adjust thrust based on continuous input
        float thrustInput = Input.GetAxis("Thrust");
        SetThrust(thrustPercent + thrustInput * thrustControlSensitivity);

        propeller.speed = thrustPercent * 1500f;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            thrustControlSensitivity *= -1;
            flapControlSensitivity *= -1;
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            brake = !brake;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            flap += flapControlSensitivity;
            //clamp
            flap = Mathf.Clamp(flap, 0f, Mathf.Deg2Rad * 40);
        }

        UpdateHUD();

        pitch = pitchControlSensitivity * Input.GetAxis("Vertical");
        roll = rollControlSensitivity * Input.GetAxis("Horizontal");
        yaw = yawControlSensitivity * Input.GetAxis("Yaw");
    }

    private void SetThrust(float percent)
    {
        thrustPercent = Mathf.Clamp01(percent);
    }
    

    private void FixedUpdate()
    {
        aircraftPhysics.SetControlSurfecesAngles(pitch, roll, yaw, flap);
        aircraftPhysics.SetThrustPercent(thrustPercent);
        aircraftPhysics.Brake(brake);
    }

      private void UpdateHUD()
        {
            hud.text = "Altitude: " + transform.position.y.ToString("F0") + " m";
        }
}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEditorInternal;
// using UnityEngine;
// using UnityEngine.SceneManagement;
// using TMPro;
// using UnityEngine.InputSystem;

// public class AirplaneController : MonoBehaviour
// {
//     [SerializeField]
//     float rollControlSensitivity = 0.2f;
//     [SerializeField]
//     float pitchControlSensitivity = 0.2f;
//     [SerializeField]
//     float yawControlSensitivity = 0.2f;
//     [SerializeField]
//     float thrustControlSensitivity = 0.01f;
//     [SerializeField]
//     float flapControlSensitivity = 0.15f;
//     [SerializeField] TextMeshProUGUI hud;

//     float pitch;
//     float yaw;
//     float roll;
//     float flap;
//     Rigidbody rb;

//     float thrustPercent;
//     bool brake = false;

//     AircraftPhysics aircraftPhysics;
//     Rotator propeller;

//     private InputActions inputActions;

//     private void Start()
//     {
//         aircraftPhysics = GetComponent<AircraftPhysics>();
//         propeller = FindObjectOfType<Rotator>();
//         SetThrust(0);

//         // Initialize InputActions
//         inputActions = new InputActions();
//         inputActions.Enable();
//     }

//     private void Awake()
//     {
//         rb = GetComponent<Rigidbody>();
//         UpdateHUD();
//     }

//     private void OnEnable()
//     {
//         // Subscribe to input actions
//         inputActions.FlyHelicopter.UpAction.started += context => OnUpAction();
//         inputActions.FlyHelicopter.DownAction.started += context => OnDownAction();
//         inputActions.FlyHelicopter.ForwardAction.started += context => OnForwardAction();
//         // Add subscriptions for other actions

//         inputActions.Enable();
//     }

//     private void OnDisable()
//     {
//         // Unsubscribe from input actions
//         inputActions.FlyHelicopter.UpAction.started -= context => OnUpAction();
//         inputActions.FlyHelicopter.DownAction.started -= context => OnDownAction();
//         inputActions.FlyHelicopter.ForwardAction.started -= context => OnForwardAction();
//         // Remove subscriptions for other actions

//         inputActions.Disable();
//     }

//     private void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.P))
//         {
//             SceneManager.LoadScene("MainMenu");
//         }
//         if (Input.GetKeyDown(KeyCode.R))
//         {
//             SceneManager.LoadScene(0);
//         }

//         // Adjust thrust based on continuous input
//         float thrustInput = inputActions.FlyHelicopter.UpAction.ReadValue<float>();
//         SetThrust(thrustPercent + thrustInput * thrustControlSensitivity);

//         propeller.speed = thrustPercent * 1500f;

//         if (Keyboard.current.leftShiftKey.wasPressedThisFrame)
//         {
//             thrustControlSensitivity *= -1;
//             flapControlSensitivity *= -1;
//         }

//         if (Keyboard.current.bKey.wasPressedThisFrame)
//         {
//             brake = !brake;
//         }

//         if (Keyboard.current.leftCtrlKey.wasPressedThisFrame)
//         {
//             flap += flapControlSensitivity;
//             //clamp
//             flap = Mathf.Clamp(flap, 0f, Mathf.Deg2Rad * 40);
//         }

//         UpdateHUD();

//         pitch = pitchControlSensitivity * inputActions.FlyHelicopter.ForwardAction.ReadValue<float>();
//         roll = rollControlSensitivity * inputActions.FlyHelicopter.Right.ReadValue<float>();
//         yaw = yawControlSensitivity * inputActions.FlyHelicopter.TurnRight.ReadValue<float>();
//     }

//     private void SetThrust(float percent)
//     {
//         thrustPercent = Mathf.Clamp01(percent);
//     }

//     private void FixedUpdate()
//     {
//         aircraftPhysics.SetControlSurfecesAngles(pitch, roll, yaw, flap);
//         aircraftPhysics.SetThrustPercent(thrustPercent);
//         aircraftPhysics.Brake(brake);
//     }

//     private void UpdateHUD()
//     {
//         hud.text = "Altitude: " + transform.position.y.ToString("F0") + " m";
//     }

//     // Add methods for other actions
//     private void OnUpAction()
//     {
//         Debug.Log("UPPPPS MF");
//     }

//     private void OnDownAction()
//     {
//         // Handle DownAction
//     }

//     private void OnForwardAction()
//     {
//         // Handle ForwardAction
//     }

//     // Add methods for other actions
// }