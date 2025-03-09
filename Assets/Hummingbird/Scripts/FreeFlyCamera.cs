using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FreeFlyCamera : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;         // How fast to move (WASD, Q/E)
    public float sprintMultiplier = 2f; // Shift key multiplier

    [Header("Look Settings")]
    public float lookSensitivity = 2f;  // How sensitive mouse look is
    public float maxLookAngle = 80f;    // Limit up/down angle

    private float pitch = 0f;  // Current x-rotation
    private float yaw = 0f;    // Current y-rotation

    private void Start()
    {
        // Hide and lock the mouse cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Initialize rotation from current transform
        Vector3 eulers = transform.eulerAngles;
        pitch = eulers.x;
        yaw = eulers.y;
    }

    private void Update()
    {
        // Handle movement input (WASD, Q/E)
        float forward = Input.GetAxis("Vertical");   // W/S
        float strafe = Input.GetAxis("Horizontal");  // A/D

        // Optional: Q/E for vertical up/down
        float ascend = 0f;
        if (Input.GetKey(KeyCode.E)) ascend = 1f;
        else if (Input.GetKey(KeyCode.Q)) ascend = -1f;

        float currentSpeed = moveSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            // Sprint
            currentSpeed *= sprintMultiplier;
        }

        Vector3 direction = new Vector3(strafe, ascend, forward);
        // Move relative to local transform
        Vector3 velocity = transform.TransformDirection(direction) * currentSpeed * Time.deltaTime;
        transform.position += velocity;

        // Handle mouse look
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        yaw += mouseX * lookSensitivity;
        pitch -= mouseY * lookSensitivity;
        pitch = Mathf.Clamp(pitch, -maxLookAngle, maxLookAngle);

        // Apply rotation
        transform.rotation = Quaternion.Euler(pitch, yaw, 0f);

        // Optional: Unlock/Show cursor if Escape is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
