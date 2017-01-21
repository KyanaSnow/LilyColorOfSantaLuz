using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SplineController))]
[CanEditMultipleObjects]
public class ScriptEditorSplineController : Editor {

    SerializedProperty activateDebug;
    SerializedProperty splineRoot;
    SerializedProperty timeBetweenAdjacentNodes;
    SerializedProperty orientationMode;
    SerializedProperty wrapMode;
    SerializedProperty autoClose;

    int toolBar;

    void OnEnable()
    {
        activateDebug = serializedObject.FindProperty("_ActivateDebug");
        splineRoot = serializedObject.FindProperty("SplineRoot");
        timeBetweenAdjacentNodes = serializedObject.FindProperty("TimeBetweenAdjacentNodes");
        orientationMode = serializedObject.FindProperty("OrientationMode");
        wrapMode = serializedObject.FindProperty("WrapMode");
        autoClose = serializedObject.FindProperty("AutoClose");

    }

    void OnDisable()
    {
        EditorPrefs.SetInt("index", toolBar);
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(activateDebug, new GUIContent("Activate Debug"));

        //string[] menuOptions = new string[4];
        //menuOptions[0] = "Main params";
        //menuOptions[1] = "Main params";
       // menuOptions[2] = "Main params";
        //menuOptions[3] = "Main params";


        //toolBar = GUILayout.Toolbar(toolBar, menuOptions);
        //EditorGUILayout.Space();

       // switch (toolBar)
       // {
         //   #region ONGLET 1 main params

          //  case 0:
          //      break;

         //   #endregion
       // }

        //GUI.color = Color.green;
        //if (GUILayout.Button("Add Spline"))
        //{
        //
        //}
        //GUI.color = Color.red;
        //
        //if (GUILayout.Button("Delete this Spline"))
        //{
        //
        //}
        //GUI.color = Color.white;

        if (GUI.changed)
            serializedObject.ApplyModifiedProperties();
    }
}
