using UnityEngine;

/// <summary>
/// Basic player movement script for a cube using Rigidbody physics.
/// Attach this to a cube with a Rigidbody component.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class CubeMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("Movement speed in units per second.")]
    public float moveSpeed = 5f;

    private Rigidbody rb;
    private Vector3 movementInput;

    void Awake()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();

        // Ensure Rigidbody settings are correct for player control
        rb.freezeRotation = true; // Prevent unwanted rotation from collisions
    }

    void Update()
    {
        // Get input from WASD or Arrow keys
        float moveX = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right
        float moveZ = Input.GetAxisRaw("Vertical");   // W/S or Up/Down

        // Normalize to prevent faster diagonal movement
        movementInput = new Vector3(moveX, 0f, moveZ).normalized;
    }

    void FixedUpdate()
    {
        // Apply movement in physics update
        Vector3 moveVelocity = movementInput * moveSpeed;
        Vector3 newPosition = rb.position + moveVelocity * Time.fixedDeltaTime;

        rb.MovePosition(newPosition);
    }
}