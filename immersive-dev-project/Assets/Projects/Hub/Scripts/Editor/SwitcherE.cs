using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Immersive.Hub.Sce {
    [CustomEditor(typeof(Portal), true)]
    public class SwitcherE : Editor {
        
        /// <summary>
        /// Allows developer to choose a scene asset as the next scene
        /// </summary>
        public override void OnInspectorGUI() {
            var ss = target as Portal;
            var oldScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(ss.nextSceneName);

            serializedObject.Update();

            EditorGUI.BeginChangeCheck();
            var newScene = EditorGUILayout.ObjectField("Next Scene", oldScene, typeof(SceneAsset), false) as SceneAsset;

            if (EditorGUI.EndChangeCheck()) {
                var newPath = AssetDatabase.GetAssetPath(newScene);
                var scenePathProperty = serializedObject.FindProperty("nextSceneName");
                scenePathProperty.stringValue = newPath;
            }
            serializedObject.ApplyModifiedProperties();
        }

    }
}