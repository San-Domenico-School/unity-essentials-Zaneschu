using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 20f;     // Movement speed of the character
    [SerializeField] private float mouseSensitivity = 1.2f;  // Mouse sensitivity for looking around

    private CharacterController characterController;       // Reference to the Character Controller component
    private Camera playerCamera;                           // Reference to the camera attached to the character

    private float verticalRotation = 0f;                   // Current vertical rotation of the camera

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();

        Cursor.lockState = CursorLockMode.Locked;           // Lock the cursor to the center of the screen
    }

    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        // Handle character movement
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movement = transform.forward * verticalMovement + transform.right * horizontalMovement;
        movement *= (60 * movementSpeed * Time.deltaTime);

        characterController.SimpleMove(movement);

        // Handle character rotation (looking around)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}