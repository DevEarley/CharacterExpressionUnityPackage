using CharacterExpressions;
using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
[CustomEditor(typeof(CharacterExpression_Blink_PlayableClip))]
public class CharacterExpression_Blink_PlayableClip_Editor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var clip = target as CharacterExpression_Blink_PlayableClip;
        var config = clip.Config;
        if (config == null) return;

        EditorGUI.BeginChangeCheck();
        CharacterExpression_EditorServices.OnInspectorGUI_Blink_Config(config);

        EditorGUI.EndChangeCheck();
        serializedObject.ApplyModifiedProperties();
        EditorUtility.SetDirty(config);

    }
}

