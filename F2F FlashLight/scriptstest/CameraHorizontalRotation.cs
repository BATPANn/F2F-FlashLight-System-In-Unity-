using UnityEngine;

public class CameraHorizontalRotation : MonoBehaviour
{
    [Header("Settings")]
    public float sensitivity = 2f;        // Mouse sensitivity
    public float maxLeftRotation = 30f;   // How far left (negative)
    public float maxRightRotation = 60f;  // How far right (positive)

    private float currentYaw;             // Rotation relative to center
    private float startYaw;               // Starting Y rotation

    void Start()
    {
        // Save the starting rotation as center
        startYaw = transform.localEulerAngles.y;
        currentYaw = 0f;
    }

    void Update()
    {
        // Get horizontal mouse input
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;

        // Update yaw
        currentYaw += mouseX;

        // Clamp between different left/right limits
        currentYaw = Mathf.Clamp(currentYaw, -maxLeftRotation, maxRightRotation);

        // Apply rotation relative to starting yaw
        float finalYaw = startYaw + currentYaw;
        transform.localRotation = Quaternion.Euler(0f, finalYaw, 0f);
    }
}
