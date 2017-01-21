using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ManageEventScene))]
//[CanEditMultipleObjects]
public class ScriptEditorManageEventScene : Editor
{
    SerializedProperty componentDesactiveEventManager;
    SerializedProperty startOnActivate;
    SerializedProperty listTimeStart;
    SerializedProperty listEventToLaunch;
    SerializedProperty listMyFooldOuts;

    void OnEnable()
    {
        componentDesactiveEventManager = serializedObject.FindProperty("ComponentDesactiveEventManager");
        startOnActivate = serializedObject.FindProperty("StartOnActivate");
        listTimeStart = serializedObject.FindProperty("TimeStart");
        listEventToLaunch = serializedObject.FindProperty("EventToLaunch");
        listMyFooldOuts = serializedObject.FindProperty("myFooldOuts");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(componentDesactiveEventManager);
        EditorGUILayout.PropertyField(startOnActivate);
        EditorGUILayout.Space();

        for (int i = 0; i < listTimeStart.arraySize; i++)
        {
            listMyFooldOuts.GetArrayElementAtIndex(i).boolValue = EditorGUILayout.ToggleLeft("Event " + i, listMyFooldOuts.GetArrayElementAtIndex(i).boolValue);
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

                ShowOneEvent(i);

                EditorGUILayout.EndVertical();
                EditorGUILayout.Space();
            }
        }
        if (listTimeStart.arraySize == 0 && GUILayout.Button(addButtonContent, EditorStyles.miniButton))
        {
            listMyFooldOuts.arraySize += 1;
            listTimeStart.arraySize += 1;
            listEventToLaunch.arraySize += 1;
        }
        serializedObject.ApplyModifiedProperties();
    }

    void OnInspectorUpdate()
    {
        this.Repaint();
    }

    void ShowOneEvent(int index)
    {
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Time to Start : ");
        EditorGUILayout.PropertyField(listTimeStart.GetArrayElementAtIndex(index), GUIContent.none);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("LaunchEvent : ");
        EditorGUILayout.PropertyField(listEventToLaunch.GetArrayElementAtIndex(index), GUIContent.none);
        EditorGUILayout.EndHorizontal();

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
            listTimeStart.MoveArrayElement(index, index + 1);
            listEventToLaunch.MoveArrayElement(index, index + 1);

        }
        GUI.color = Color.green;
        if (GUILayout.Button(duplicateButtonContent, EditorStyles.miniButtonMid))
        {
            listMyFooldOuts.InsertArrayElementAtIndex(index);
            listTimeStart.InsertArrayElementAtIndex(index);
            listEventToLaunch.InsertArrayElementAtIndex(index);
        }
        GUI.color = Color.red;
        if (GUILayout.Button(deleteButtonContent, EditorStyles.miniButtonRight))
        {
            int oldSize = listTimeStart.arraySize;
            listMyFooldOuts.DeleteArrayElementAtIndex(index);
            if (listMyFooldOuts.arraySize == oldSize)
            {
                listMyFooldOuts.DeleteArrayElementAtIndex(index);
            }

            listTimeStart.DeleteArrayElementAtIndex(index);
            if (listTimeStart.arraySize == oldSize)
            {
                listTimeStart.DeleteArrayElementAtIndex(index);
            }

            listEventToLaunch.DeleteArrayElementAtIndex(index);
            if (listEventToLaunch.arraySize == oldSize)
            {
                listEventToLaunch.DeleteArrayElementAtIndex(index);
            }
        }
        GUI.color = Color.white;
        EditorGUILayout.EndVertical();
    }
}
