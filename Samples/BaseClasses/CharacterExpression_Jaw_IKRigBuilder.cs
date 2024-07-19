using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;


#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(CharacterExpression_Jaw_IKRigBuilder))]
public class CharacterExpression_Jaw_IKRigBuilder_Button : Editor
{
    override public void OnInspectorGUI()
    {
        CharacterExpression_Jaw_IKRigBuilder builder = (CharacterExpression_Jaw_IKRigBuilder)target;
        if (GUILayout.Button("Build Jaw Rig"))
        {
            builder.BuildJawRig();
        }
        DrawDefaultInspector();
    }
}
#endif


public class CharacterExpression_Jaw_IKRigBuilder : MonoBehaviour
{

    public GameObject JawBone;
    public GameObject CharacterRoot;

    public void BuildJawRig()
    {
        var RigBuilder = CharacterRoot.GetComponent<RigBuilder>();
        if (RigBuilder == null)
        {
          RigBuilder = CharacterRoot.AddComponent<RigBuilder>();
        }
        var JawIKRig = new GameObject();
        JawIKRig.name = "JawIkRig";
        JawIKRig.transform.parent = CharacterRoot.transform;
      var rig = JawIKRig.AddComponent<Rig>();
        var JawIKRig_TransformOverride = new GameObject();
        JawIKRig_TransformOverride.name = "JawIKRig_TransformOverride";
        JawIKRig_TransformOverride.transform.parent = JawIKRig.transform;
        JawIKRig_TransformOverride.AddComponent<OverrideTransform>();
        var JawIKRig_Target = new GameObject();
        JawIKRig_Target.name = "JawIkRig_Target";
        JawIKRig_Target.transform.parent = JawIKRig.transform;
        JawIKRig_Target.transform.position = JawBone.transform.position;
        var overrideTransform  = JawIKRig_TransformOverride.GetComponent<OverrideTransform>();
        //overrideTransform.constrainedObject = JawBone.transform;
        var data = new OverrideTransformData();
        data.sourceObject = JawIKRig_Target.transform;
        data.constrainedObject = JawBone.transform;
        data.space = OverrideTransformData.Space.Pivot;
        data.rotationWeight = 1.0f;
        data.positionWeight = 0.0f;
        overrideTransform.data = data;
        RigBuilder.layers.Add(new RigLayer(rig,true));
        //complete
        GameObject.DestroyImmediate(CharacterRoot.GetComponent<CharacterExpression_Jaw_IKRigBuilder>());
    }
}
