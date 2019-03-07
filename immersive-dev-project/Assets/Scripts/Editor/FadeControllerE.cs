﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FadeController))]
public class FadeControllerE : Editor {

    public override void OnInspectorGUI() {
        var fc = target as FadeController;
        serializedObject.Update();

        var serProp = serializedObject.GetIterator();
        while (serProp.NextVisible(true)) {
            switch (serProp.name.ToLower()) {
                case "m_script":
                    break;
                case "speed":
                    EditorGUI.BeginChangeCheck();
                    float speed = EditorGUILayout.FloatField("Speed", fc.speed);

                    if (EditorGUI.EndChangeCheck()) {
                        fc.speed = speed;
                        fc.anim.SetFloat("Speed", speed);
                    }
                    break;
                case "fadecolor":
                    EditorGUI.BeginChangeCheck();
                    Color color = EditorGUILayout.ColorField("Fade Color", fc.fadeColor);

                    if (EditorGUI.EndChangeCheck()) {
                        fc.fadeColor = color;
                        if(fc.fadeImage != null) {
                            fc.fadeImage.color = color;
                        }
                    }
                    break;
                default:
                    EditorGUILayout.PropertyField(serProp);
                    break;
            }
        }
        serializedObject.ApplyModifiedProperties();
        serializedObject.Update();
    }

}
