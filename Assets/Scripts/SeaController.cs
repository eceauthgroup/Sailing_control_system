// using UnityEngine;

// namespace UnityStandardAssets.Water
// {
//     public class WindWaveController : MonoBehaviour
//     {
//         public WindController windController;
//         public float waveHeightMultiplier = 2f;

//         private WaterBase waterBase;

//         private void Start()
//         {
//             waterBase = GetComponent<WaterBase>();
//             if (waterBase == null)
//             {
//                 Debug.LogWarning("WaterBase component not found!");
//             }
//         }

//         private void Update()
//         {
//             if (windController != null && waterBase != null)
//             {
//                 // Update the wave direction based on wind direction
//                 Vector3 windDirection = windController.WindDirection.normalized;
//                 waterBase.WindDirection = new Vector2(windDirection.x, windDirection.z);

//                 // Update the wave height based on wind speed
//                 float windSpeed = windController.WindSpeed;
//                 waterBase.WaveScale = new Vector2(windSpeed, windSpeed) * waveHeightMultiplier;
//             }
//         }
//     }
// }
