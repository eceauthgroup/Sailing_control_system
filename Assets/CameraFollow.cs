using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Reference to the boat's transform
    public Vector3 offset; // Offset from the boat's position
    
    private void LateUpdate()
    {
        if (target != null)
        {
            // Set the camera's position to the boat's position with the offset
            transform.position = target.position + offset;

            transform.LookAt(target);
        }
    }
}
