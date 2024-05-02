using UnityEngine;

public class CarController : MonoBehaviour
{
    public float acceleration = 5.0f;
    public float braking = 5.0f;
    public float maxSpeed = 10.0f;
    public float turnSpeed = 100.0f;

    private UnityEngine.Rigidbody rb;
    private float horizontalInput;
    private float verticalInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        UserInput();
    }

    void FixedUpdate()
    {
        Move();
    }

    void UserInput()
    {
        // Get input from arrow keys or WASD
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    void Move()
    {
        // Calculate acceleration and braking
        float targetSpeed = verticalInput * maxSpeed;
        float accelerationValue = verticalInput > 0 ? acceleration : braking;
        float currentSpeed = rb.velocity.magnitude;

        // Calculate force to apply
        float force = (targetSpeed - currentSpeed) * accelerationValue;
        rb.AddRelativeForce(Vector3.forward * force);

        // Rotate the car based on horizontal input
        Quaternion turnRotation = Quaternion.Euler(0.0f, horizontalInput * turnSpeed * Time.fixedDeltaTime, 0.0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}

    