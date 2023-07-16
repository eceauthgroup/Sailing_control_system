

using UnityEngine;
using UnityEditor;

namespace UnityStandardAssets.Water
{
    [CustomEditor(typeof(GerstnerDisplace))]
    public class GerstnerDisplaceEditor : Editor
    {
        private SerializedObject serObj;
        private float previousRotation = 0.0f;

        public void OnEnable()
        {
            serObj = new SerializedObject(target);

            // Subscribe to the wind direction changed event
            WindController.OnWindDirectionChanged += OnWindDirectionChanged;
        }

        public void OnDisable()
        {
            // Unsubscribe from the wind direction changed event
            WindController.OnWindDirectionChanged -= OnWindDirectionChanged;
        }

        float Remap(float value, float fromMin, float fromMax, float toMin, float toMax)
        {
            return (value - fromMin) / (fromMax - fromMin) * (toMax - toMin) + toMin;
        }

        public override void OnInspectorGUI()
        {
            serObj.Update();

            GerstnerDisplace gerstnerDisplace = (GerstnerDisplace)target;
            GameObject go = gerstnerDisplace.gameObject;
            WaterBase wb = go.GetComponent<WaterBase>();
            Material sharedWaterMaterial = wb.sharedMaterial;

            GUILayout.Label("Animates vertices using up 4 generated waves", EditorStyles.miniBoldLabel);

            if (sharedWaterMaterial)
            {
                Vector4 amplitude = WaterEditorUtility.GetMaterialVector("_GAmplitude", sharedWaterMaterial);
                Vector4 frequency = WaterEditorUtility.GetMaterialVector("_GFrequency", sharedWaterMaterial);
                Vector4 steepness = WaterEditorUtility.GetMaterialVector("_GSteepness", sharedWaterMaterial);
                Vector4 speed = WaterEditorUtility.GetMaterialVector("_GSpeed", sharedWaterMaterial);
                Vector4 directionAB = WaterEditorUtility.GetMaterialVector("_GDirectionAB", sharedWaterMaterial);
                Vector4 directionCD = WaterEditorUtility.GetMaterialVector("_GDirectionCD", sharedWaterMaterial);

                amplitude = EditorGUILayout.Vector4Field("Amplitude (Height offset)", amplitude);
                frequency = EditorGUILayout.Vector4Field("Frequency (Tiling)", frequency);
                steepness = EditorGUILayout.Vector4Field("Steepness", steepness);
                speed = EditorGUILayout.Vector4Field("Speed", speed);

                // Get wind rotation
                Quaternion windRotation = WindController.WindRotation;
                //Get wind speed
                float windSpeed = WindController.WindSpeed;

                //To be removed
                int currentRotation = (int)windRotation.eulerAngles.y;
                if (currentRotation != previousRotation)
                {
                    previousRotation = currentRotation;
                    Debug.Log(currentRotation);
                }

                if (currentRotation > 365)
                {
                    int modulo = currentRotation % 360;
                    currentRotation -= 360 * modulo;
                }

                if (currentRotation < -365)
                {
                    int modulo = currentRotation % 360;
                    currentRotation += 360 * modulo;
                }

                if ((currentRotation >= -5 && currentRotation <= 5) || (currentRotation <= -355 && currentRotation >= -365))
                {
                    directionCD.x = 0;
                    directionCD.y = 0;
                    directionCD.z = 0;
                    directionCD.w = -2;
                    directionAB.x = 0;
                    directionAB.y = 0;
                    directionAB.z = 0;
                    directionAB.w = 0;
                }

                if ((currentRotation >= 40 && currentRotation <= 50) || (currentRotation <= -310 && currentRotation >= -320))
                {
                    directionCD.x = 0;
                    directionCD.y = 0;
                    directionCD.z = -2;
                    directionCD.w = -2;
                    directionAB.x = 0;
                    directionAB.y = 0;
                    directionAB.z = 0;
                    directionAB.w = 0;
                }

                if ((currentRotation >= 85 && currentRotation <= 95) || (currentRotation <= -265 && currentRotation >= -275))
                {
                    directionCD.x = 0;
                    directionCD.y = 0;
                    directionCD.z = -2;
                    directionCD.w = 0;
                    directionAB.x = 0;
                    directionAB.y = 0;
                    directionAB.z = 0;
                    directionAB.w = 0;
                }

                if ((currentRotation >= 130 && currentRotation <= 140) || (currentRotation <= -220 && currentRotation >= -230))
                {
                    directionCD.x = 0;
                    directionCD.y = 0;
                    directionCD.z = -2;
                    directionCD.w = 2;
                    directionAB.x = 0;
                    directionAB.y = 0;
                    directionAB.z = 0;
                    directionAB.w = 0;
                }

                if ((currentRotation >= 175 && currentRotation <= 185) || (currentRotation <= -175 && currentRotation >= -185))
                {
                    directionCD.x = 0;
                    directionCD.y = 0;
                    directionCD.z = 0;
                    directionCD.w = 2;
                    directionAB.x = 0;
                    directionAB.y = 0;
                    directionAB.z = 0;
                    directionAB.w = 0;
                }

                if ((currentRotation >= 220 && currentRotation <= 230) || (currentRotation <= -130 && currentRotation >= -140))
                {
                    directionCD.x = 0;
                    directionCD.y = 0;
                    directionCD.z = 2;
                    directionCD.w = 2;
                    directionAB.x = 0;
                    directionAB.y = 0;
                    directionAB.z = 0;
                    directionAB.w = 0;
                }

                if ((currentRotation >= 265 && currentRotation <= 275) || (currentRotation <= -85 && currentRotation >= -95))
                {
                    directionCD.x = 0;
                    directionCD.y = 0;
                    directionCD.z = 2;
                    directionCD.w = 0;
                    directionAB.x = 0;
                    directionAB.y = 0;
                    directionAB.z = 0;
                    directionAB.w = 0;
                }

                if ((currentRotation >= 310 && currentRotation <= 320) || (currentRotation <= -40 && currentRotation >= -50))
                {
                    directionCD.x = 0;
                    directionCD.y = 0;
                    directionCD.z = 2;
                    directionCD.w = -2;
                    directionAB.x = 0;
                    directionAB.y = 0;
                    directionAB.z = 0;
                    directionAB.w = 0;
                }

                //In order for the speed of the wave to go from 1 up to 8
                speed.w = Remap(windSpeed,1f,50f,1f,5f);
                Debug.Log("Water speed: " + speed.w);

                //In order for the speed of the wave to go from 0.5 up to 2
                amplitude.w = Remap(windSpeed, 1f, 50f, 0.1f, 0.5f);
                Debug.Log("Water height: " + amplitude.w);

                // // Convert wind rotation to wave direction
                // Vector2 waveDirection = new Vector2(windRotation.eulerAngles.x, windRotation.eulerAngles.y);

                // // Set directionAB and directionCD based on waveDirection
                // directionAB.x = waveDirection.x;
                // directionAB.y = waveDirection.y;
                // directionCD.z = waveDirection.x;
                // directionCD.w = waveDirection.y;

                directionAB = EditorGUILayout.Vector4Field("Direction scale (Wave 1 (X,Y) and 2 (Z,W))", directionAB);
                directionCD = EditorGUILayout.Vector4Field("Direction scale (Wave 3 (X,Y) and 4 (Z,W))", directionCD);

                WaterEditorUtility.SetMaterialVector("_GAmplitude", amplitude, sharedWaterMaterial);
                WaterEditorUtility.SetMaterialVector("_GFrequency", frequency, sharedWaterMaterial);
                WaterEditorUtility.SetMaterialVector("_GSteepness", steepness, sharedWaterMaterial);
                WaterEditorUtility.SetMaterialVector("_GSpeed", speed, sharedWaterMaterial);
                WaterEditorUtility.SetMaterialVector("_GDirectionAB", directionAB, sharedWaterMaterial);
                WaterEditorUtility.SetMaterialVector("_GDirectionCD", directionCD, sharedWaterMaterial);

                if (GUI.changed)
                {
                    
                }
            }

            serObj.ApplyModifiedProperties();
        }

        private void OnWindDirectionChanged(Quaternion newRotation)
        {
            // Redraw the inspector GUI when the wind direction changes
            
            Repaint();
        }
    }
}
