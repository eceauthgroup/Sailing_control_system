using UnityEngine;

public class WaterBase : MonoBehaviour
{
    public float waterHeight = 0.5f;
    public float waterScale = 0.1f;
    public Vector3 waveDirection = Vector3.forward;

    public Shader waterShader;
    public Material sharedMaterial;

    private WindController windController;

    private void Start()
    {
        sharedMaterial = new Material(waterShader);
        GetComponent<Renderer>().sharedMaterial = sharedMaterial;

        windController = FindObjectOfType<WindController>();
    }

    private void Update()
    {
        if (sharedMaterial != null)
        {
            // Set water height and scale in the shader
            sharedMaterial.SetFloat("_WaterHeight", waterHeight + WindController.WindSpeed * 0.1f); // Adjust the height based on wind speed
            sharedMaterial.SetFloat("_WaterScale", waterScale);

            if (windController != null)
            {
                // Set wind direction in the shader based on wave direction
                sharedMaterial.SetVector("_WindDirection", waveDirection.normalized);

                // Set wind speed in the shader
                sharedMaterial.SetFloat("_WindSpeed", WindController.WindSpeed);
            }
        }
    }

    public Material GetSharedMaterial()
    {
        return sharedMaterial;
    }
}
