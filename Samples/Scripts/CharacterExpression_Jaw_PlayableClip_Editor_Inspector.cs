#if UNITY_EDITOR
using CharacterExpressions;
using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
[CustomEditor(typeof(CharacterExpression_Jaw_PlayableClip))]
public class CharacterExpression_Jaw_PlayableClip_Editor_Inspector : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var clip = target as CharacterExpression_Jaw_PlayableClip;
        var config = clip.jawConfig;
        if (config == null) return;

        EditorGUI.BeginChangeCheck();
        CharacterExpression_EditorServices.OnInspectorGUI_Jaw_Config(config);

        EditorGUI.EndChangeCheck();
        serializedObject.ApplyModifiedProperties();
        EditorUtility.SetDirty(config);

    }

}

#endif