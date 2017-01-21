using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ManageCameraRoom))]
[CanEditMultipleObjects]
public class ScriptEditorManageCameraRoom : Editor
{
    public GameObject obj;

    SerializedProperty IsFirstRoom;
    SerializedProperty RotationCamera;
    SerializedProperty IsCameraLookAtOrientation;
    SerializedProperty IsCameraTmpPosRot;
    SerializedProperty IsKeepRotationInZoom;
    SerializedProperty IsFirstSplineNode;

    SerializedProperty ZoomIfFarAway;
    SerializedProperty ZoomOnRotation;
    SerializedProperty MaxDistBeforeMove;
    SerializedProperty SmoothRotation;
    SerializedProperty SmoothPosition;
    SerializedProperty DistMove;
    SerializedProperty SpeedSmooth;

    SerializedProperty ListObjectToDesactive;
    SerializedProperty ListObjectToActive;


    //SerializedProperty Walk;
    //SerializedProperty Run;
    //SerializedProperty Crouch;
    //SerializedProperty ContextualAction;
    //SerializedProperty CarryDaughter;
    //SerializedProperty OrderDaughter;


    int toolBar;

    void OnEnable()
    {
        IsFirstRoom = serializedObject.FindProperty("_firstRoom");

        IsCameraLookAtOrientation = serializedObject.FindProperty("_cameraLookAtOrientation");
        IsCameraTmpPosRot = serializedObject.FindProperty("_cameraTmpPosRot");
        RotationCamera = serializedObject.FindProperty("_rotationCamera");
        IsKeepRotationInZoom = serializedObject.FindProperty("_keepRotationInZoom");
        IsFirstSplineNode = serializedObject.FindProperty("_firstSplineNode");

        ZoomIfFarAway = serializedObject.FindProperty("_zoomIfFarAway");
        ZoomOnRotation = serializedObject.FindProperty("_zoomOnRotation");
        MaxDistBeforeMove = serializedObject.FindProperty("_maxDistBeforeMove");

        SmoothRotation = serializedObject.FindProperty("_smoothRotation");
        SmoothPosition = serializedObject.FindProperty("_smoothPosition");

        DistMove = serializedObject.FindProperty("_distToMove");
        SpeedSmooth = serializedObject.FindProperty("_speedSmooth");

        ListObjectToDesactive = serializedObject.FindProperty("listObjectToDesactive");
        ListObjectToActive = serializedObject.FindProperty("listObjectToActive");


        //Walk = serializedObject.FindProperty("_walk");
        //Run = serializedObject.FindProperty("_run");
        //Crouch = serializedObject.FindProperty("_crouch");
        //ContextualAction = serializedObject.FindProperty("_contextualAction");
        //CarryDaughter = serializedObject.FindProperty("_carryDaughter");
        //OrderDaughter = serializedObject.FindProperty("_orderDaughter");


        toolBar = EditorPrefs.GetInt("index", 0);
    }

    void OnDisable()
    {
        EditorPrefs.SetInt("index", toolBar);
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(IsFirstSplineNode, new GUIContent("First SplineNode"));

        GUI.color = Color.red;
        if (GUILayout.Button("Replace MainCamera"))
        {
            var test = IsFirstSplineNode.objectReferenceValue as GameObject;
            Camera.main.transform.position = test.transform.position;
            Camera.main.transform.rotation = test.transform.rotation;
        }
        GUI.color = Color.white;

        string[] menuOptions = new string[4];

        menuOptions[0] = "Main params";
        menuOptions[1] = "Orientation";
        menuOptions[2] = "Zoom";
        menuOptions[3] = "Smooth";

        //menuOptions[4] = "Player";
        toolBar = GUILayout.Toolbar(toolBar, menuOptions);
        EditorGUILayout.Space();

        switch (toolBar)
        {
            #region ONGLET 1 main params
            case 0:
                EditorGUILayout.PropertyField(IsFirstRoom, new GUIContent("Is first Room"));
                if (IsFirstRoom.boolValue)
                    EditorGUILayout.HelpBox("Only one per Scene is the first room.", MessageType.Info);
                EditorGUILayout.PropertyField(ListObjectToActive, new GUIContent("Object To active"), true);
                EditorGUILayout.PropertyField(ListObjectToDesactive, new GUIContent("Object To desactive"), true);
            break;
            #endregion

            #region ONGLET 2 rotate
            case 1:
                EditorGUILayout.PropertyField(RotationCamera, new GUIContent("Rotation Camera"));
                if (RotationCamera.enumValueIndex == 2 || RotationCamera.enumValueIndex == 1)
                {
                    if (!ZoomIfFarAway.boolValue)
                        GUI.enabled = false;
                    EditorGUILayout.PropertyField(IsKeepRotationInZoom, new GUIContent("ZoomInRotation"));
                    GUI.enabled = true;
                }
                if (RotationCamera.enumValueIndex == 0 || RotationCamera.enumValueIndex == 2)
                    GUI.enabled = false;
                else
                {
                    EditorGUILayout.PropertyField(IsCameraLookAtOrientation, new GUIContent("Rotation"));
                    EditorGUILayout.Space();
                    EditorGUILayout.HelpBox("This is the GameObject ref for the look at. Drag and drop your gameObject Ref", MessageType.Info);
                }
                GUI.enabled = false;
                EditorGUILayout.PropertyField(IsCameraTmpPosRot, new GUIContent("Rotation"));
                GUI.enabled = true;

                //if (IsLookAtPlayer.boolValue)
                //{
                //    GUI.enabled = false;
                //    CanRotate.boolValue = false;
                //    EditorGUILayout.HelpBox("Disable Look at player if you want Rotate the camera.", MessageType.Info);
                //}
                //else
                //    GUI.enabled = true;

                //EditorGUILayout.PropertyField(CanRotate, new GUIContent("LookAtPoint"));
                //GUI.enabled = true;
                //
                //if (CanRotate.boolValue)
                //{
                //    EditorGUILayout.PropertyField(IsCameraLookAtOrientation, new GUIContent("Rotation"));
                //    EditorGUILayout.Space();
                //    EditorGUILayout.HelpBox("This is the GameObject ref for the rotation of Camera and look at", MessageType.Info);
                //}
            break;
            #endregion

            #region ONGLET 3 zoom
            case 2:
            EditorGUILayout.PropertyField(ZoomIfFarAway, new GUIContent("Can zoom"));
            if (!ZoomIfFarAway.boolValue)
            {
                GUI.enabled = false;
                ZoomOnRotation.boolValue = false;
            }
            EditorGUILayout.PropertyField(ZoomOnRotation, new GUIContent("Keep forward camera"));

            EditorGUILayout.PropertyField(MaxDistBeforeMove, new GUIContent("Max Dist Before Move"));
            GUI.enabled = true;


            //EditorGUILayout.PropertyField(CanZoom, new GUIContent("Can zoom"));

            //if (CanZoom.boolValue)
            //{
            //    EditorGUILayout.IntSlider(CameraZoomSpeed, 1, 10, new GUIContent("Zoom speed"));
            //    //EditorGUILayout.PropertyField(CameraZoomSpeed, new GUIContent("Zoom speed"));
            //    if (!CameraZoomSpeed.hasMultipleDifferentValues)
            //        ProgressBar(CameraZoomSpeed.intValue / 10.0f, "Zoom Speed");

            //    EditorGUILayout.IntSlider(CameraZoom, 20, 60, new GUIContent("Zoom FOV"));
            //    //EditorGUILayout.PropertyField(CameraZoom, new GUIContent("Zoom FOV"));
            //    if (!CameraZoom.hasMultipleDifferentValues)
            //        ProgressBar(CameraZoom.intValue / 60.0f, "Zoom FOV");
            //}

            break;
            #endregion

            #region ONGLET 4 Smooth
            case 3:

                GUILayout.Label("Smooth Transition room");

                EditorGUILayout.PropertyField(SmoothRotation, new GUIContent("Rotation"));
                EditorGUILayout.PropertyField(SmoothPosition, new GUIContent("Position"));

                EditorGUILayout.Space();

                EditorGUILayout.IntSlider(DistMove, 0, 100, new GUIContent("Dist before move"));
                if (!DistMove.hasMultipleDifferentValues)
                    ProgressBar(DistMove.intValue / 100.0f, "Distance");

                EditorGUILayout.Space();

                EditorGUILayout.IntSlider(SpeedSmooth, 0, 10, new GUIContent("Speed smooth"));
                if (!SpeedSmooth.hasMultipleDifferentValues)
                    ProgressBar(SpeedSmooth.intValue / 10.0f, "Smooth");

            break;
            #endregion

            #region ONGLET 5 PlayerControl
            //case 4:
            //GUILayout.Label("Authorize Player Control");
            //
            //EditorGUILayout.PropertyField(Walk, new GUIContent("Walk"));
            //EditorGUILayout.PropertyField(Run, new GUIContent("Run"));
            //EditorGUILayout.PropertyField(Crouch, new GUIContent("Crouch"));
            //EditorGUILayout.PropertyField(ContextualAction, new GUIContent("Contextual Action"));
            //EditorGUILayout.PropertyField(CarryDaughter, new GUIContent("Carry daughter"));
            //EditorGUILayout.PropertyField(OrderDaughter, new GUIContent("Order daughter"));
            //
            //break;
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
