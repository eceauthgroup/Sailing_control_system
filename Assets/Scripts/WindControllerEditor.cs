// using UnityEditor;
// using UnityEngine;

// [CustomEditor(typeof(WindController))]
// public class WindControllerEditor : Editor
// {
//     private SerializedProperty minSpeedProperty;
//     private SerializedProperty maxSpeedProperty;

//     private void OnEnable()
//     {
//         minSpeedProperty = serializedObject.FindProperty("minSpeed");
//         maxSpeedProperty = serializedObject.FindProperty("maxSpeed");
//     }

//     public override void OnInspectorGUI()
//     {
//         base.OnInspectorGUI();

//         serializedObject.Update();

//         EditorGUILayout.LabelField("Current Wind Speed: " + WindController.WindSpeed.ToString());

//         EditorGUILayout.PropertyField(minSpeedProperty);
//         EditorGUILayout.PropertyField(maxSpeedProperty);

//         serializedObject.ApplyModifiedProperties();
//     }
// }
