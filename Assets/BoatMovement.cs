// using UnityEngine;

// [RequireComponent(typeof(Rigidbody))]
// public class BoatMovement : MonoBehaviour
// {
//     private float rotationStep = 5f;    // Rotation step when pressing the right or left key
//     private float currentYRotation = 0f; // Current y rotation value

//     public float waterLevel = 0.0f;
//     public float amplitude = 0.1f;
//     public float frequency = 1.0f;
//     public float speed = 1.0f;
//     public float rotationSpeed = 1.0f;
//     public float rotationIncrementX = 0.01f;
//     public float rotationIncrementZ = 0.01f;

//     private Rigidbody rb;
//     private Quaternion initialRotation;
//     private float currentRotationX;
//     private float currentRotationZ;
//     private int rotationDirectionX = 1;
//     private int rotationDirectionZ = 1;

//     private void Start()
//     {
//         rb = GetComponent<Rigidbody>();
//         initialRotation = transform.rotation;
//         currentRotationX = 0.0f;
//         currentRotationZ = 0.0f;
//     }

//     private void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.RightArrow))
//         {
//             RotateBoat(rotationStep);
//         }
//         else if (Input.GetKeyDown(KeyCode.LeftArrow))
//         {
//             RotateBoat(-rotationStep);
//         }

//         // Calculate the wave displacement based on time and frequency
//         float waveDisplacement = amplitude * Mathf.Sin(Time.time * frequency);

//         // Calculate the target position with the wave displacement
//         Vector3 targetPosition = new Vector3(transform.position.x, waterLevel + waveDisplacement, transform.position.z);

//         // Move the boat towards the target position
//         Vector3 movementDirection = (targetPosition - transform.position).normalized;
//         Vector3 movement = movementDirection * speed * Time.deltaTime;
//         rb.MovePosition(transform.position + movement);

//         // Rotate the boat to align with the movement direction
//         Quaternion targetRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
//         rb.MoveRotation(Quaternion.Lerp(rb.rotation, targetRotation, rotationSpeed * Time.deltaTime));

//         // Update the x rotation
//         currentRotationX += rotationIncrementX * rotationDirectionX;
//         if (currentRotationX >= 10.0f || currentRotationX <= -10.0f)
//         {
//             rotationDirectionX *= -1;
//         }

//         // Update the z rotation
//         currentRotationZ += rotationIncrementZ * rotationDirectionZ;
//         if (currentRotationZ >= 5.0f || currentRotationZ <= -5.0f)
//         {
//             rotationDirectionZ *= -1;
//         }

//         // Apply the rotations to the boat
//         transform.rotation = initialRotation * Quaternion.Euler(currentRotationX, currentYRotation, currentRotationZ);
//     }

//     private void RotateBoat(float angle)
//     {
//         // Update the current y rotation value
//         currentYRotation += angle;

//         // Clamp the y rotation within the range of -10 to 10
//         currentYRotation = Mathf.Clamp(currentYRotation, -10f, 10f);
//     }
// }
