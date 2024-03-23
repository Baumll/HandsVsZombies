using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ZombieLimbsScript))]
public class ZombieEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ZombieLimbsScript controller = (ZombieLimbsScript)target;
        if(GUILayout.Button("Disable Limb"))
        {
            controller.DisableLimb();
        }
        base.OnInspectorGUI();
    }
}
