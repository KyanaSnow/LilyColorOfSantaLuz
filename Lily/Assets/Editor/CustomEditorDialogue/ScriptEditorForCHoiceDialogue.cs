using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(EventMakeChoice))]
public class ScriptEditorForCHoiceDialogue : Editor
{
    SerializedProperty choiceAFrench;
    SerializedProperty choiceAEnglish;

    SerializedProperty choiceBFrench;
    SerializedProperty choiceBEnglish;

    SerializedProperty aChoiceActive;
    SerializedProperty bChoiceActive;

    SerializedProperty choiceAPermanentDesactivate;
    SerializedProperty choiceBPermanentDesactivate;

    SerializedProperty timerToAnswer;
    SerializedProperty gameObjectToDesactive;

    void OnEnable()
    {
        choiceAFrench = serializedObject.FindProperty("ChoiceAFrench");
        choiceAEnglish = serializedObject.FindProperty("ChoiceAEnglish");
        choiceBFrench = serializedObject.FindProperty("ChoiceBFrench");
        choiceBEnglish = serializedObject.FindProperty("ChoiceBEnglish");
        aChoiceActive = serializedObject.FindProperty("AChoiceActive");
        bChoiceActive = serializedObject.FindProperty("BChoiceActive");
        choiceAPermanentDesactivate = serializedObject.FindProperty("ChoiceAPermanentDesactivate");
        choiceBPermanentDesactivate = serializedObject.FindProperty("ChoiceBPermanentDesactivate");

        timerToAnswer = serializedObject.FindProperty("TimerToAnswer");
        gameObjectToDesactive = serializedObject.FindProperty("GameObjectToDesactive");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(timerToAnswer);
        EditorGUILayout.PropertyField(gameObjectToDesactive);
        EditorGUILayout.Space();

        GUILayout.Label("Choice A French : ");
        EditorGUILayout.PropertyField(choiceAFrench, GUIContent.none, GUILayout.Height(50));
        GUILayout.Label("Choice A English : ");
        EditorGUILayout.PropertyField(choiceAEnglish, GUIContent.none, GUILayout.Height(50));
        EditorGUILayout.PropertyField(aChoiceActive);
        EditorGUILayout.PropertyField(choiceAPermanentDesactivate);

        EditorGUILayout.Space();

        GUILayout.Label("Choice B French : ");
        EditorGUILayout.PropertyField(choiceBFrench, GUIContent.none, GUILayout.Height(50));
        GUILayout.Label("Choice B English : ");
        EditorGUILayout.PropertyField(choiceBEnglish, GUIContent.none, GUILayout.Height(50));
        EditorGUILayout.PropertyField(bChoiceActive);
        EditorGUILayout.PropertyField(choiceBPermanentDesactivate);
        serializedObject.ApplyModifiedProperties();
    }

    void OnInspectorUpdate()
    {
        this.Repaint();
    }
}
