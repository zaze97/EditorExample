using System;
using UnityEditor;
using UnityEngine;

namespace EditorWindows
{
    [CustomEditorWindow(1)]
    public class CustomWindows :EditorWindow
    {
        private void OnGUI()
        {
            GUILayout.Label("这是一个自定义窗口");
        }
    }
}