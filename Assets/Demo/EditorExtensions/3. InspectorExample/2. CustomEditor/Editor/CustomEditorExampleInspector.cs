using System;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    [CustomEditor(typeof(CustomEditorExample))]
    public class CustomEditorExampleInspector : UnityEditor.Editor
    {
        CustomEditorExample mTarget
        {
            get { return target as CustomEditorExample; }
        }
        

        public override void OnInspectorGUI()
        {
            var hpRect = GUILayoutUtility.GetRect(18,18,"TextField");
            EditorGUI.ProgressBar(hpRect, mTarget.HP,"HP");
            
            var rangeRect = GUILayoutUtility.GetRect(18,18,"TextField");
            EditorGUI.ProgressBar(rangeRect, mTarget.Range,"Range");

            EditorGUILayout.BeginHorizontal("box");
            EditorGUILayout.LabelField("角色名",GUILayout.Width(100));
            mTarget.RoleName = EditorGUILayout.TextArea(mTarget.RoleName);
            EditorGUILayout.EndHorizontal();
            
            EditorGUILayout.ObjectField(serializedObject.FindProperty("OtherObj"));
            serializedObject.ApplyModifiedProperties();
        }
    }
}