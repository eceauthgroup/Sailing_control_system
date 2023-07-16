using UnityEngine;

public class SailBoatController : MonoBehaviour
{
    public float turnSpeed = 100f;
    public float driftForce = 10f;
    private Rigidbody boatRigidbody;
    private bool isTurningLeft = false;
    private bool isTurningRight = false;

    private void Start()
    {
        boatRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            isTurningLeft = true;
            isTurningRight = false;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            isTurningLeft = false;
            isTurningRight = true;
        }
        else
        {
            isTurningLeft = false;
            isTurningRight = false;
        }

    }

    void RotateY(float angle)
    {
        Vector3 euler = transform.rotation.eulerAngles;
        float newY = (euler.y + angle) % 360;
        if (newY < 0)
            newY += 360;
        transform.rotation = Quaternion.Euler(euler.x, newY, euler.z);
    }

    void TurnLeft()
    {
        // Apply torque to the sailboat's rigidbody to turn left
        // Use the negative turnSpeed to rotate in the opposite direction
        //boatRigidbody.AddTorque(Vector3.up * -turnSpeed);
        RotateY(-turnSpeed * Time.deltaTime);

    }



    void TurnRight()
    {
        // Apply torque to the sailboat's rigidbody to turn right
        //boatRigidbody.AddTorque(Vector3.up * turnSpeed);
        RotateY(turnSpeed * Time.deltaTime);

    }

    private void FixedUpdate()
    {
        if (isTurningLeft)
        {
            TurnLeft();
        }
        else if (isTurningRight)
        {
            TurnRight();
        }
    }

}