using CharacterExpressions;
using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
[CustomEditor(typeof(CharacterExpression_BlendShapes_PlayableClip))]
public class CharacterExpression_BlendShapes_PlayableClip_Editor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var clip = target as CharacterExpression_BlendShapes_PlayableClip;

        //var config = clip.jawConfig;
        //if (config == null) return;

        //EditorGUI.BeginChangeCheck();
        //CharacterExpression_EditorServices.OnInspectorGUI_Jaw_Config(config);

        //EditorGUI.EndChangeCheck();
        //serializedObject.ApplyModifiedProperties();
        //EditorUtility.SetDirty(config);

    }
}

