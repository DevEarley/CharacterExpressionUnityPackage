#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(CharacterExpression_Blink_Configuration))]
public class CharacterExpression_Blink_Configuration_Editor : Editor
{

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        var config = target as CharacterExpression_Blink_Configuration;
        if (config == null) return;
        EditorGUI.BeginChangeCheck();
        CharacterExpression_EditorServices.OnInspectorGUI_Blink_Config(config);

        // TODO: if the config changed, store in the clip some how? also show "save as..." button.

        EditorGUI.EndChangeCheck();
        serializedObject.ApplyModifiedProperties();
        EditorUtility.SetDirty(config);
    }


}
#endif

