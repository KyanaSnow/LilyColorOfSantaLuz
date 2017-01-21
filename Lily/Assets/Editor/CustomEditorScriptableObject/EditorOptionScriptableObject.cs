using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(OptionScriptableObject))]

public class EditorOptionScriptableObject : Editor
{
    #region MainOption
    SerializedProperty language;
    SerializedProperty quality;
    SerializedProperty volumeMusic;
    SerializedProperty volumeSoundEffect;
    SerializedProperty volumeAmbient;
    #endregion

    #region Camera
    SerializedProperty SensibilityStickChange;
    #endregion

    #region Save
    SerializedProperty curCheckpoint;
    SerializedProperty curMoodLily;
    #endregion

    #region Diary
    SerializedProperty catchPicture;
    #endregion

    int toolBar;

    void OnEnable()
    {
        language = serializedObject.FindProperty("Language");
        quality = serializedObject.FindProperty("Quality");
        volumeMusic = serializedObject.FindProperty("VolumeMusic");
        volumeSoundEffect = serializedObject.FindProperty("VolumeSoundEffect");
        volumeAmbient = serializedObject.FindProperty("VolumeAmbient");
        SensibilityStickChange = serializedObject.FindProperty("SensibilityStickChangeDirectionControl");
        curCheckpoint = serializedObject.FindProperty("CurCheckpoint");
        curMoodLily = serializedObject.FindProperty("CurMoodLily");
        catchPicture = serializedObject.FindProperty("CatchPicture");
    }

    void OnDisable()
    {
        EditorPrefs.SetInt("index", toolBar);
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        string[] menuOptions = new string[3];
        menuOptions[0] = "Main params";
        menuOptions[1] = "Camera";
        //menuOptions[2] = "Diary";
        menuOptions[2] = "Save";


        toolBar = GUILayout.Toolbar(toolBar, menuOptions);
        EditorGUILayout.Space();

        switch (toolBar)
        {
            #region ONGLET 1 main params
            case 0:
                EditorGUILayout.PropertyField(language, new GUIContent("Language"));
                EditorGUILayout.PropertyField(quality, new GUIContent("Quality Settings"));
                EditorGUILayout.Space();

                GUILayout.Label("Volume :");
                EditorGUILayout.PropertyField(volumeMusic, new GUIContent("Music"));
                EditorGUILayout.PropertyField(volumeSoundEffect, new GUIContent("Sound Effect"));
                EditorGUILayout.PropertyField(volumeAmbient, new GUIContent("Ambient"));
                break;
            #endregion

            #region ONGLET 2 Camera

            case 1:
                EditorGUILayout.PropertyField(SensibilityStickChange, new GUIContent("SensiStickDirection"));
                break;
            #endregion

            //#region ONGLET 3 Diary

            //case 2:
            //    EditorGUILayout.PropertyField(catchPicture, new GUIContent("Picture Catch"));
            //    break;
            //#endregion

            #region ONGLET 4 Sava

            case 2:
                EditorGUILayout.PropertyField(curCheckpoint, new GUIContent("Current checkpoint"));
                EditorGUILayout.PropertyField(curMoodLily, new GUIContent("Mood Lily"));
                break;
            #endregion
        }

        if (GUI.changed)
            serializedObject.ApplyModifiedProperties();
    }

    // Custom GUILayout progress bar.
    void ProgressBar(float value, string label)
    {
        // Get a rect for the progress bar using the same margins as a textfield:
        Rect rect = GUILayoutUtility.GetRect(18, 18, "TextField");
        EditorGUI.ProgressBar(rect, value, label);
        EditorGUILayout.Space();
    }
}
