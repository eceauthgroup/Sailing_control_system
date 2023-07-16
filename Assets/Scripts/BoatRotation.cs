using UnityEngine;

public class BoatRotation : MonoBehaviour
{
    private float rotationStep = 5f;    // Rotation step when pressing the right or left key
    private float currentYRotation = 0f; // Current y rotation value

    public float CurrentYRotation => currentYRotation; // Expose the current y rotation value

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RotateBoat(rotationStep);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            RotateBoat(-rotationStep);
        }
    }

    private void RotateBoat(float angle)
    {
        // Get the current rotation of the boat
        Vector3 currentRotation = transform.rotation.eulerAngles;

        // Calculate the new rotation by adding the angle
        Vector3 newRotation = new Vector3(currentRotation.x, currentRotation.y + angle, currentRotation.z);

        // Apply the new rotation to the boat
        transform.rotation = Quaternion.Euler(newRotation);

        // Update the current y rotation value
        currentYRotation = newRotation.y;
    }
}
