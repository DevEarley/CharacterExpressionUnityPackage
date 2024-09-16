#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(CharacterExpression_BlendShapes_Configuration))]
public class CharacterExpression_BlendShapes_Configuration_Editor : Editor
{

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        var config = target as CharacterExpression_BlendShapes_Configuration;
        base.OnInspectorGUI();
        //if (config == null) return;
        //EditorGUI.BeginChangeCheck();
        //CharacterExpression_EditorServices.OnInspectorGUI_Jaw_Config(config);

        //// TODO: if the config changed, store in the clip some how? also show "save as..." button.

        //EditorGUI.EndChangeCheck();
        //serializedObject.ApplyModifiedProperties();
        //EditorUtility.SetDirty(config);
    }


}
#endif

