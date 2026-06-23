using UnityEngine;

/// <summary>
/// Attach this script to your Main Camera in Unity.
/// Assign the target (e.g., Cube) in the Inspector.
/// The camera will follow the target with a fixed offset.
/// </summary>
public class CameraFollow : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform target; // The object to follow (e.g., Cube)

    [Header("Camera Offset")]
    public Vector3 offset = new Vector3(0f, 5f, -10f); // Default offset

    [Header("Follow Settings")]
    [Range(0.01f, 1f)]
    public float smoothSpeed = 0.125f; // Smoothness factor

    private void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("CameraFollow: No target assigned!");
            return;
        }

        // Desired position based on target + offset
        Vector3 desiredPosition = target.position + offset;

        // Smoothly interpolate between current and desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Apply position
        transform.position = smoothedPosition;

        // Optionally look at the target
        transform.LookAt(target);
    }
}