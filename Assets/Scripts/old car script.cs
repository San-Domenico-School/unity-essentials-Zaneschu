using UnityEngine;

public class SimpleCarController : MonoBehaviour
{
    public float acceleration = 5.0f;
    public float braking = 5.0f;
    public float maxSpeed = 10.0f;
    public float turnSpeed = 100.0f;

    private Rigidbody rb;
    private float horizontalInput;
    private float verticalInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = 1.0f; // Adjust as needed for realism
        rb.drag = 1.0f; // Higher drag to prevent floating
        rb.angularDrag = 0.5f; // Small angular drag to stabilize rotation
        rb.useGravity = true; // Ensure gravity is applied
        rb.isKinematic = false; // Ensure physics affects the Rigidbody
    }

    void Update()
    {
        // Get input from arrow keys or WASD
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        // Calculate target speed based on vertical input
        float targetSpeed = verticalInput * maxSpeed;
        float accelerationValue = verticalInput > 0 ? acceleration : braking;
        float currentSpeed = Vector3.Dot(rb.velocity, transform.forward);

        // Calculate force to apply
        float force = (targetSpeed - currentSpeed) * accelerationValue;

        // Apply force in the car's local forward direction
        if (verticalInput != 0)
        {
            rb.AddForce(transform.forward * force, ForceMode.Acceleration);
        }

        // Limit velocity to max speed
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

        // Calculate rotation based on horizontal input
        float turn = horizontalInput * turnSpeed * Time.fixedDeltaTime;

        // Apply rotation to the car
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0, turn, 0));
    }
}
