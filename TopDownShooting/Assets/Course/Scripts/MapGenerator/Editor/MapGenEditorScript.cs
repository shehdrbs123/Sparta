using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(MapGen))]
public class MapGenEditorScript : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        MapGen m = (MapGen)target;
        
        
        if (GUILayout.Button("Test Move"))
        {
            m.GenerateMap();
        }
    }
}
