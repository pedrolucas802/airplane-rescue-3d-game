using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaneController : MonoBehaviour
{
  [Header("Plane Stats")]
  [Tooltip("How much the throttle ramps up or down.")]
  public float throttleIncrement = 0.02f;
  [Tooltip("Maximum engine thrust when at 100% throttle.")]
  public float maxThrust = 75f;
  [Tooltip("How responsive the plane is when rolling, pitching and yawing.")]
  public float responsiveness = 20f; 

    private Transform propeller;
    private Animator animator; 

  [Tooltip("How much lift force the plane generates as it gains speed.")]
  public float lift = 50f;
  private float throttle;
  private float roll;
  private float pitch;
  private float yaw;

  private float responseModifier
  {
    get
    {
      return (rb.mass / 10f) * responsiveness;
    }
  }

  Rigidbody rb;
  [SerializeField] TextMeshProUGUI hud;
  [SerializeField] Transform propella;

  private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        // propeller = GameObject.FindGameObjectWithTag("Propeller").transform;
        animator = GetComponentInChildren<Animator>(); // Use GetComponentInChildren if the Animator is a child

        if (propeller == null)
        {
            Debug.LogError("Propeller not found. Make sure it has the 'Propeller' tag.");
        }
        if (animator == null)
        {
            Debug.LogError("Animator not found on the GameObject or its children.");
        }
    }

  private void HandleInputs()
  {
    // Set rotation values from our axis inputs.
    roll = Input.GetAxis("Roll");
    pitch = Input.GetAxis("Pitch");
    yaw = Input.GetAxis("Yaw");
    float thrustInput = Input.GetAxis("Thrust"); //velocidade

    // Handle throttle value being sure to clamp it between 0 and 100.
    if (Input.GetKey(KeyCode.Space)) throttle += throttleIncrement;
    else if (Input.GetKey(KeyCode.B) && (throttle >= 25 || transform.position.y <= 1)) throttle -= throttleIncrement;
    throttle = Mathf.Clamp(throttle, 0f, 100f);


    // if (thrustInput > 0 || Input.GetKey(KeyCode.Space) throttle += throttleIncrement;
    // else if (thrustInput < 0 || Input.GetKey(KeyCode.N)) throttle -= throttleIncrement;
    // throttle = Mathf.Clamp(throttle, 0f, 100f);
  }

    private void Update()
    {
        HandleInputs();
        UpdateHUD();
        RotatePropeller();

        // Check for engine start input and trigger the animation
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartEngineAnimation();
        }
    }

  private void FixedUpdate()
  {
    // Apply forces to our plane.
    rb.AddForce(transform.forward * maxThrust * throttle);
    rb.AddTorque(transform.up * pitch * responseModifier);
    rb.AddTorque(transform.right * yaw * responseModifier);
    rb.AddTorque(-transform.forward * roll * responseModifier);

    rb.AddForce(Vector3.up * rb.velocity.magnitude * lift);


    
  }

  private void UpdateHUD()
  {
    hud.text = "Throttle " + throttle.ToString("F0") + "%\n";
    hud.text += "Airspeed: " + (rb.velocity.magnitude * 3.6f).ToString("F0") + "km/h\n";
    hud.text += "Altitude: " + transform.position.y.ToString("F0") + " m";
  }

  private void RotatePropeller()
    {
        if (propeller != null)
        {
            // Calculate rotation speed based on throttle
            float rotationSpeed = throttle * 10f; // You can adjust the multiplier to control the rotation speed

            // Rotate the propeller
            propeller.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }


   private void StartEngineAnimation()
    {
        if (animator != null)
        {
            // Trigger the "EngineOn" animation
            animator.SetTrigger("EngineOn");
        }
    }

}

