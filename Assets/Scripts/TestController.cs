using UnityEngine;

public class TestController : MonoBehaviour
{
    public float movementAmount = 1.0f;
    public float turnSpeed = 100f;
    public float driftForce = 10f;
    private Rigidbody boatRigidbody;
    private bool isTurningLeft = false;
    private bool isTurningRight = false;
    private float rotationStep = 5f;
    private float currentYRotation = 0f;
    public float constantSpeed = 1.0f;

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

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RotateBoat(rotationStep);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            RotateBoat(-rotationStep);
        }

        if (Input.GetKey(KeyCode.W))
        {
            MoveForward();
        }
    }

    private void FixedUpdate()
    {
        if (isTurningLeft)
        {
            RotateY(-turnSpeed * Time.deltaTime);
        }
        else if (isTurningRight)
        {
            RotateY(turnSpeed * Time.deltaTime);
        }

        float boatRotationY = transform.eulerAngles.y;
        float windRotationY = WindController.WindRotation.eulerAngles.y;

        if (boatRotationY < 0)
        {
            boatRotationY += 360;
        }

        if ((boatRotationY >= 0 && boatRotationY < 45 || boatRotationY >= 180 && boatRotationY < 225) &&
            (windRotationY == 0 || windRotationY == -365))
        {
            transform.Translate(0, 0, movementAmount * Time.deltaTime);
        }
        else if ((boatRotationY >= 0 && boatRotationY < 45 || boatRotationY >= 180 && boatRotationY < 225) &&
                 (windRotationY == 180 || windRotationY == -180))
        {
            transform.Translate(0, 0, -movementAmount * Time.deltaTime);
        }
        else if ((boatRotationY >= 90 && boatRotationY < 135 || boatRotationY >= 270 && boatRotationY < 315) &&
                 (windRotationY == 90 || windRotationY == -270))
        {
            transform.Translate(movementAmount * Time.deltaTime, 0, 0, Space.World);
        }
        else if ((boatRotationY >= 90 && boatRotationY < 135 || boatRotationY >= 270 && boatRotationY < 315) &&
                 (windRotationY == 270 || windRotationY == -90))
        {
            transform.Translate(-movementAmount * Time.deltaTime, 0, 0, Space.World);
        }
        else if ((boatRotationY >= 45 && boatRotationY < 90 || boatRotationY >= 225 && boatRotationY < 270) &&
                 (windRotationY == 45 || windRotationY == -315))
        {
            transform.Translate(movementAmount * Time.deltaTime, 0, 0, Space.World);
        }
        else if ((boatRotationY >= 45 && boatRotationY < 90 || boatRotationY >= 225 && boatRotationY < 270) &&
                 (windRotationY == 225 || windRotationY == -135))
        {
            transform.Translate(-movementAmount * Time.deltaTime, 0, 0, Space.World);
        }
        else if ((boatRotationY >= 135 && boatRotationY < 180 || boatRotationY >= 315 && boatRotationY < 360) &&
                 (windRotationY == 135 || windRotationY == -225))
        {
            transform.Translate(movementAmount * Time.deltaTime, 0, 0, Space.World);
        }
        else if ((boatRotationY >= 135 && boatRotationY < 180 || boatRotationY >= 315 && boatRotationY < 360) &&
                 (windRotationY == 315 || windRotationY == -45))
        {
            transform.Translate(-movementAmount * Time.deltaTime, 0, 0, Space.World);
        }
    }

    private void RotateY(float angle)
    {
        Vector3 euler = transform.rotation.eulerAngles;
        float newY = (euler.y + angle) % 360;
        if (newY < 0)
        {
            newY += 360;
        }
        transform.rotation = Quaternion.Euler(euler.x, newY, euler.z);
        currentYRotation = newY;
    }

    private void RotateBoat(float angle)
    {
        Vector3 currentRotation = transform.rotation.eulerAngles;
        Vector3 newRotation = new Vector3(currentRotation.x, currentRotation.y + angle, currentRotation.z);
        transform.rotation = Quaternion.Euler(newRotation);
        currentYRotation = newRotation.y;
    }

    private void MoveForward()
    {
        Vector3 movement = new Vector3(-1f,0f,0f).normalized * constantSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
}


