using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 10f;
    public float turnSpeed = 50f;

    private Rigidbody rb;

    void Start()
    {
        // Get the Rigidbody component attached to the car
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get input from the player
        float moveForward = Input.GetAxis("Vertical") * speed;
        float turn = Input.GetAxis("Horizontal") * turnSpeed;

        // Move the car forward or backward
        Vector3 movement = transform.forward * moveForward * Time.deltaTime;
        rb.MovePosition(rb.position + movement);

        // Rotate the car
        Quaternion turnRotation = Quaternion.Euler(0f, turn * Time.deltaTime, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
