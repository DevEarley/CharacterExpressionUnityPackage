#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(CharacterExpression_Jaw_Configuration))]
public class CharacterExpression_Jaw_Configuration_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        var config = target as CharacterExpression_Jaw_Configuration;
        if (config == null) return;
        EditorGUI.BeginChangeCheck();
        CharacterExpression_EditorServices.OnInspectorGUI_Jaw_Config(config);
        EditorGUI.EndChangeCheck();
        serializedObject.ApplyModifiedProperties();
        EditorUtility.SetDirty(config);
    }
}
#endif

