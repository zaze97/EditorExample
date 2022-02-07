

using System;
using EditorWindows;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    [CustomEditorWindow(2)]
    public class GUIBaseExample :EditorWindow
    {
        Label _label1=new Label("123");
        Label _label2=new Label("123");
        private void OnGUI()
        {
            _label1.OnGUI(default);
            _label2.OnGUI(default);
        }
    }
}