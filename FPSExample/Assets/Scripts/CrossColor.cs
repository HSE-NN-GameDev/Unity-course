using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class CrossColor : MonoBehaviour
{
    public Color color;
    
    public Image[] FindImages()
    {
        return GetComponentsInChildren<Image>();
    }
}

[CustomEditor(typeof(CrossColor))]
public class CrossColorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CrossColor myScript = (CrossColor)target;
        if (GUILayout.Button("Apply Color"))
        {
            Image[] images = myScript.FindImages();
            foreach (Image img in images)
            {
                img.color = myScript.color;
                PrefabUtility.RecordPrefabInstancePropertyModifications(img);
            }
        }
    }
}
