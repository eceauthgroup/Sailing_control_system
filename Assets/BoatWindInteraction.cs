using UnityEngine;

public class BoatWindInteraction : MonoBehaviour
{
    public float movementAmount = 1.0f; // Amount to move the boat
    private BoatRotation boatRotation;

    private void Start()
    {
        boatRotation = GetComponent<BoatRotation>();
    }

    private void Update()
    {
        float boatRotationY = transform.eulerAngles.y;
        float windRotationY = WindController.WindRotation.eulerAngles.y;

        if (boatRotationY < 0)
        {
            boatRotationY += 360;
        }

        // Option 1
        if ((boatRotationY >= 0 && boatRotationY < 45 || boatRotationY >= 180 && boatRotationY < 225) &&
            (windRotationY == 0 || windRotationY == -365))
        {
            transform.Translate(0, 0, movementAmount * Time.deltaTime);
        }
        // Option 2
        else if ((boatRotationY >= 0 && boatRotationY < 45 || boatRotationY >= 180 && boatRotationY < 225) &&
                 (windRotationY == 180 || windRotationY == -180))
        {
            transform.Translate(0, 0, -movementAmount * Time.deltaTime);
        }
        // Option 3
        else if ((boatRotationY >= 90 && boatRotationY < 135 || boatRotationY >= 270 && boatRotationY < 315) &&
                 (windRotationY == 90 || windRotationY == -270))
        {
            transform.Translate(movementAmount * Time.deltaTime, 0, 0, Space.World);
        }
        // Option 4
        else if ((boatRotationY >= 90 && boatRotationY < 135 || boatRotationY >= 270 && boatRotationY < 315) &&
                 (windRotationY == 270 || windRotationY == -90))
        {
            transform.Translate(-movementAmount * Time.deltaTime, 0, 0, Space.World);
        }
        // Option 5
        else if ((boatRotationY >= 45 && boatRotationY < 90 || boatRotationY >= 225 && boatRotationY < 270) &&
                 (windRotationY == 45 || windRotationY == -315))
        {
            transform.Translate(movementAmount * Time.deltaTime, 0, 0, Space.World);
        }
        // Option 6
        else if ((boatRotationY >= 45 && boatRotationY < 90 || boatRotationY >= 225 && boatRotationY < 270) &&
                 (windRotationY == 225 || windRotationY == -135))
        {
            transform.Translate(-movementAmount * Time.deltaTime, 0, 0, Space.World);
        }
        // Option 7
        else if ((boatRotationY >= 135 && boatRotationY < 180 || boatRotationY >= 315 && boatRotationY < 360) &&
                 (windRotationY == 135 || windRotationY == -225))
        {
            transform.Translate(movementAmount * Time.deltaTime, 0, 0, Space.World);
        }
        // Option 8
        else if ((boatRotationY >= 135 && boatRotationY < 180 || boatRotationY >= 315 && boatRotationY < 360) &&
                 (windRotationY == 315 || windRotationY == -45))
        {
            transform.Translate(-movementAmount * Time.deltaTime, 0, 0, Space.World);
        }
    }
}
