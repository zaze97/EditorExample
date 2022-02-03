using System;
using UnityEditor;
using UnityEngine;

namespace EditorWindows
{
    [CustomEditorWindow]
    public class CustomWindows :EditorWindow
    {
        private void OnGUI()
        {
            GUILayout.Label("这是一个自定义窗口");
        }
    }
}