using System;
using UnityEditor;
using UnityEngine;

public class WindowsExample : EditorWindow
{
    [MenuItem("Editor/02.EditorWindows/Open")]
    static void OpenEditorWindows()
    {
        GetWindow<WindowsExample>().Show();
    }

    private string TextField;
    private string TextArea;
    private string PasswordField = string.Empty;

    private void OnGUI()
    {
        GUILayout.Label("窗口打开");
        GUILayout.Label("--------输入框--------");
        GUILayout.BeginHorizontal();
        {
            GUILayout.Label("TextField");
            TextField = GUILayout.TextField(TextField);
        }
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        {
            GUILayout.Label("TextArea");
            TextArea = GUILayout.TextArea(TextArea);
        }
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        {
            GUILayout.Label("PasswordField");
            PasswordField = GUILayout.PasswordField(PasswordField, '*');
        }
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        {
            GUILayout.Label("Button(按下执行一次)");
            if (GUILayout.Button("Button"))
            {
                Debug.Log("Button按钮按下");
            }
        }
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        {
            GUILayout.Label("RepeatButton(按下和抬起都会执行一次)");
            if (GUILayout.RepeatButton("RepeatButton"))
            {
                Debug.Log("RepeatButton按钮按下");
            }
        }
        GUILayout.EndHorizontal();
    }
}