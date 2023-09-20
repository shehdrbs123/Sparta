
using System;

namespace Practice.Scripts.MapGen.Editor
{
    using UnityEditor;
    using UnityEngine;
    [CustomEditor(typeof(MapTool))]
    public class MapToolEditorScript : Editor
    {
        private MapTool tool;

        private SerializedProperty MapTheme;
        public void OnEnable()
        {
            tool = target as MapTool;

            MapTheme = serializedObject.FindProperty(nameof(MapTheme));
        }

        public override void OnInspectorGUI()
        {
            
            if (GUILayout.Button("맵 생성"))
            {
                tool.MakeMap();
            }

            if (GUILayout.Button("Theme Reload"))
            {
                tool.UpdateTilePersents();
            }

            Object tmp = MapTheme.objectReferenceValue;
            EditorGUILayout.PropertyField(MapTheme);
            serializedObject.ApplyModifiedProperties();
            if(tmp != MapTheme.objectReferenceValue)
                tool.UpdateTilePersents();
            base.OnInspectorGUI();
        }
    }
}