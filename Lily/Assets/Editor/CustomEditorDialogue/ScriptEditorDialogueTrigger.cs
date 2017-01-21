using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TriggerDialogue))]
[CanEditMultipleObjects]
public class ScriptEditorDialogueTrigger : Editor
{
    SerializedProperty startOnActivate;

    SerializedProperty listTimeToStart;
    SerializedProperty listTimeDisplay;
    SerializedProperty listFrenchDialogue;
    SerializedProperty listEnglishDialogue;
    SerializedProperty listAttachDialogue;
    SerializedProperty listOtherAttach;
    SerializedProperty listLaunchEvent;
    SerializedProperty listMyFooldOuts;
    SerializedProperty listRelatedSoundString;


    void OnEnable()
    {
        startOnActivate = serializedObject.FindProperty("StartOnActivate");

        listTimeToStart = serializedObject.FindProperty("TimeToStart");
        listTimeDisplay = serializedObject.FindProperty("TimeDisplay");
        listFrenchDialogue = serializedObject.FindProperty("FrenchDialogue");
        listEnglishDialogue = serializedObject.FindProperty("EnglishDialogue");
        listAttachDialogue = serializedObject.FindProperty("AttachDialogue");
        listOtherAttach = serializedObject.FindProperty("OtherAttach");
        listLaunchEvent = serializedObject.FindProperty("LaunchEvent");
        listRelatedSoundString = serializedObject.FindProperty("RelatedSoundString");

        listMyFooldOuts = serializedObject.FindProperty("myFooldOuts");
    }

    public override void OnInspectorGUI()
    {
        //DrawDefaultInspector();
        EditorGUILayout.PropertyField(startOnActivate);
        EditorGUILayout.Space();

        for (int i = 0; i < listTimeToStart.arraySize; i++)
        {
            //listMyFooldOuts.GetArrayElementAtIndex(i).boolValue = EditorGUILayout.Foldout(listMyFooldOuts.GetArrayElementAtIndex(i).boolValue, "Dialogue " + i, EditorStyles.boldLabel);
            listMyFooldOuts.GetArrayElementAtIndex(i).boolValue = EditorGUILayout.ToggleLeft("Dialogue " + i, listMyFooldOuts.GetArrayElementAtIndex(i).boolValue);
            float test;
            if (listMyFooldOuts.GetArrayElementAtIndex(i).boolValue)
                test = 0;
            else
            {
                test = 1;
            }
            //if (EditorGUILayout.BeginFadeGroup(if(listMyFooldOuts.GetArrayElementAtIndex(i).boolValue))
            if (listMyFooldOuts.GetArrayElementAtIndex(i).boolValue)
            {
                EditorGUILayout.BeginVertical();

                ShowOneDialogue(i);

                EditorGUILayout.EndVertical();
                EditorGUILayout.Space();
            }
        }
        if (listTimeToStart.arraySize == 0 && GUILayout.Button(addButtonContent, EditorStyles.miniButton))
        {
            listMyFooldOuts.arraySize += 1;
            listTimeToStart.arraySize += 1;
            listTimeDisplay.arraySize += 1;
            listFrenchDialogue.arraySize += 1;
            listEnglishDialogue.arraySize += 1;
            listAttachDialogue.arraySize += 1;
            listOtherAttach.arraySize += 1;
            listLaunchEvent.arraySize += 1;
            listRelatedSoundString.arraySize += 1;
        }
        serializedObject.ApplyModifiedProperties();
        serializedObject.Update();
    }

    void OnInspectorUpdate()
    {
        this.Repaint();
    }

    void ShowOneDialogue(int index)
    {
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Time to Start : ");
        EditorGUILayout.PropertyField(listTimeToStart.GetArrayElementAtIndex(index), GUIContent.none);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Display time : ");
        EditorGUILayout.PropertyField(listTimeDisplay.GetArrayElementAtIndex(index), GUIContent.none);
        EditorGUILayout.EndHorizontal();

        GUILayout.Label("French Dialogue : ");
        EditorGUILayout.PropertyField(listFrenchDialogue.GetArrayElementAtIndex(index), GUIContent.none, GUILayout.Height(50));

        GUILayout.Label("English Dialogue : ");
        EditorGUILayout.PropertyField(listEnglishDialogue.GetArrayElementAtIndex(index), GUIContent.none, GUILayout.Height(50));

        EditorGUILayout.PropertyField(listAttachDialogue.GetArrayElementAtIndex(index), GUIContent.none);

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Other Attach : ");
        EditorGUILayout.PropertyField(listOtherAttach.GetArrayElementAtIndex(index), GUIContent.none);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("LaunchEvent : ");
        EditorGUILayout.PropertyField(listLaunchEvent.GetArrayElementAtIndex(index), GUIContent.none);
        EditorGUILayout.EndHorizontal();

        GUILayout.Label("String Sound : ");
        EditorGUILayout.PropertyField(listRelatedSoundString.GetArrayElementAtIndex(index), GUIContent.none, GUILayout.Height(20));
        ShowButtons(index);

    }

    private GUIContent
    moveButtonContent = new GUIContent("Down", "move down"),
    duplicateButtonContent = new GUIContent("+", "duplicate"),
    deleteButtonContent = new GUIContent("-", "delete"),
    addButtonContent = new GUIContent("+", "add element");

    //private GUILayoutOption miniButtonWidth = GUILayout.Width(40f);


    void ShowButtons(int index)
    {
        EditorGUILayout.BeginHorizontal("Button");
        if (GUILayout.Button(moveButtonContent, EditorStyles.miniButtonLeft))
        {
            listMyFooldOuts.MoveArrayElement(index, index + 1);
            listTimeToStart.MoveArrayElement(index, index + 1);
            listTimeDisplay.MoveArrayElement(index, index + 1);
            listFrenchDialogue.MoveArrayElement(index, index + 1);
            listEnglishDialogue.MoveArrayElement(index, index + 1);
            listAttachDialogue.MoveArrayElement(index, index + 1);
            listOtherAttach.MoveArrayElement(index, index + 1);
            listLaunchEvent.MoveArrayElement(index, index + 1);
            listRelatedSoundString.MoveArrayElement(index, index + 1);


        }
        GUI.color = Color.green;
        if (GUILayout.Button(duplicateButtonContent, EditorStyles.miniButtonMid))
        {
            listMyFooldOuts.InsertArrayElementAtIndex(index);
            listTimeToStart.InsertArrayElementAtIndex(index);
            listTimeDisplay.InsertArrayElementAtIndex(index);
            listFrenchDialogue.InsertArrayElementAtIndex(index);
            listEnglishDialogue.InsertArrayElementAtIndex(index);
            listAttachDialogue.InsertArrayElementAtIndex(index);
            listOtherAttach.InsertArrayElementAtIndex(index);
            listLaunchEvent.InsertArrayElementAtIndex(index);
            listRelatedSoundString.InsertArrayElementAtIndex(index);

        }
        GUI.color = Color.red;
        if (GUILayout.Button(deleteButtonContent, EditorStyles.miniButtonRight))
        {
            int oldSize = listTimeToStart.arraySize;
            listMyFooldOuts.DeleteArrayElementAtIndex(index);
            if (listMyFooldOuts.arraySize == oldSize)
            {
                listMyFooldOuts.DeleteArrayElementAtIndex(index);
            }

            listTimeToStart.DeleteArrayElementAtIndex(index);
            if (listTimeToStart.arraySize == oldSize)
            {
                listTimeToStart.DeleteArrayElementAtIndex(index);
            }

            listTimeDisplay.DeleteArrayElementAtIndex(index);
            if (listTimeDisplay.arraySize == oldSize)
            {
                listTimeDisplay.DeleteArrayElementAtIndex(index);
            }

            listFrenchDialogue.DeleteArrayElementAtIndex(index);
            if (listFrenchDialogue.arraySize == oldSize)
            {
                listFrenchDialogue.DeleteArrayElementAtIndex(index);
            }

            listEnglishDialogue.DeleteArrayElementAtIndex(index);
            if (listEnglishDialogue.arraySize == oldSize)
            {
                listEnglishDialogue.DeleteArrayElementAtIndex(index);
            }

            listAttachDialogue.DeleteArrayElementAtIndex(index);
            if (listAttachDialogue.arraySize == oldSize)
            {
                listAttachDialogue.DeleteArrayElementAtIndex(index);
            }

            listOtherAttach.DeleteArrayElementAtIndex(index);
            if (listOtherAttach.arraySize == oldSize)
            {
                listOtherAttach.DeleteArrayElementAtIndex(index);
            }

            listLaunchEvent.DeleteArrayElementAtIndex(index);
            if (listLaunchEvent.arraySize == oldSize)
            {
                listLaunchEvent.DeleteArrayElementAtIndex(index);
            }

            listRelatedSoundString.DeleteArrayElementAtIndex(index);
            if (listRelatedSoundString.arraySize == oldSize)
            {
                listRelatedSoundString.DeleteArrayElementAtIndex(index);
            }
        }
        GUI.color = Color.white;
        EditorGUILayout.EndVertical();
    }
}
