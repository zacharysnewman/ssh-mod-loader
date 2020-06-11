using UnityEditor;
using UnityEngine;

// IngredientDrawer
[CustomPropertyDrawer(typeof(KeyValueType))]
public class KeyValueTypeDrawer : PropertyDrawer
{
    // Draw the property inside the given rect
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var key = property.FindPropertyRelative("Key");
        var value = property.FindPropertyRelative("Value");
        var type = property.FindPropertyRelative("Type");

        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        // Draw label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), new GUIContent(key.stringValue + " : " + type.stringValue));

        // Don't make child fields be indented
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        // Calculate rects
        // var amountRect = new Rect(position.x, position.y, 30, position.height);
        // var unitRect = new Rect(position.x + 35, position.y, 50, position.height);
        var nameRect = new Rect(position.x, position.y, position.width, position.height);

        // Draw fields - passs GUIContent.none to each so they are drawn without labels
        // EditorGUI.PropertyField(amountRect, key, GUIContent.none);
        // EditorGUI.PropertyField(unitRect, value, GUIContent.none);
        EditorGUI.PropertyField(nameRect, value, GUIContent.none);

        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }
}