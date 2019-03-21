using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SceneSwitcher))]
public class PortalE : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        //SceneSwitcher sc = (SceneSwitcher)target;
        //string name = sc.name ?? "";
        //var temp = EditorGUILayout.TextField("Next Scene", sc.name);
        //if(temp != name)
        //{

        //}
    }

}
