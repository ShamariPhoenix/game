using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(WaveData))]
public class WaveDataDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Extract the index from the property path (e.g., "waveData.Array.data[0]")
        int index = int.Parse(property.propertyPath.Split('[', ']')[1]);
        
        // Change the label text
        label.text = $"Wave {index + 1}";

        // Draw the rest of the property as normal
        EditorGUI.PropertyField(position, property, label, true);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property, label, true);
    }
}