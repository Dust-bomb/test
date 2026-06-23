using UnityEngine;

public class CubeJump : MonoBehaviour
{
    [Header("Jump Settings")]
    public float jumpForce = 5f; // Force applied when jumping
    public LayerMask groundLayer; // Layer that represents the ground

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody component missing! Please add one to the cube.");
        }
    }

    void Update()
    {
        // Check if the cube is on the ground
        isGrounded = Physics.CheckSphere(transform.position + Vector3.down * 0.5f, 0.2f, groundLayer);

        // Jump when Space is pressed and cube is grounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        // Reset vertical velocity before applying jump force
        Vector3 velocity = rb.linearVelocity;
        velocity.y = 0;
        rb.linearVelocity = velocity;

        // Apply upward force
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    // Draw ground check sphere in Scene view for debugging
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + Vector3.down * 0.5f, 0.2f);
    }
}