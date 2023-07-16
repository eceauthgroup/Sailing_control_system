using UnityEngine;

public class WindController : MonoBehaviour
{
    public static float WindSpeed = 1.0f;
    public static Quaternion WindRotation = Quaternion.identity;

    public float speedChange = 5;
    public int changeSpeedIntervalInSeconds = 5;

    public float minWindSpeed = 1;
    public float maxWindSpeed = 100;

    private float changeTimer = 0.0f;
    public int changeDirectionIntervalInSeconds = 5;


    private Transform windTransform;

    // Define event delegate
    public delegate void WindDirectionChangedHandler(Quaternion newRotation);
    // Define event
    public static event WindDirectionChangedHandler OnWindDirectionChanged;

    private void Start()
    {
        windTransform = transform; // Cache the wind object's transform
        RandomizeWind();
    }

    private void Update()
    {
        changeTimer += Time.deltaTime;

        if (changeTimer >= changeDirectionIntervalInSeconds)
        {
            RandomizeWind();
            updateWindSpeed();
            changeTimer = 0.0f;

            // Apply wind rotation to the wind object
            windTransform.rotation = WindRotation;

            // Trigger the wind direction changed event
            OnWindDirectionChanged?.Invoke(WindRotation);
        }

        //Debug.Log("change timer: "+changeTimer);
        //if (changeTimer >= changeSpeedIntervalInSeconds)
        //{
        //    updateWindSpeed();
        //}
    }

    // private void RandomizeWind()
    // {
    //     WindSpeed = Random.Range(minSpeed, maxSpeed);
    //     float angleX = Random.Range(0.0f, 360.0f);
    //     float angleY = Random.Range(0.0f, 360.0f);
    //     float angleZ = Random.Range(0.0f, 360.0f);
    //     WindRotation = Quaternion.Euler(0.0f, angleY, 0.0f);
    // }
    private void RandomizeWind()
    {
        int angleIndex = Random.Range(-1, 2);
        float angleY = transform.eulerAngles.y + (angleIndex * 45);
        WindRotation = Quaternion.Euler(0.0f, angleY, 0.0f);
    }

    private void updateWindSpeed()
    {
        int changeWindSpeed = Random.Range(0, 2);
        ParticleSystem.MainModule mainModule = GetComponent<ParticleSystem>().main;
        if (changeWindSpeed == 0)
        {
            Debug.Log("To increase speed");
            if (mainModule.startSpeed.constant + speedChange < maxWindSpeed)
                mainModule.startSpeed = mainModule.startSpeed.constant + speedChange;
            else
                mainModule.startSpeed = maxWindSpeed;
        }
        else if (changeWindSpeed == 1)
        {
            Debug.Log("To decrease speed");
            if (mainModule.startSpeed.constant - speedChange > minWindSpeed)
                mainModule.startSpeed = mainModule.startSpeed.constant - speedChange;
            else
                 mainModule.startSpeed = minWindSpeed;
        }
        WindSpeed = mainModule.startSpeed.constant;
        Debug.Log("Current Wind Speed: " + WindSpeed);
    }
     
}
