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
    public enum PageId
    {
        Basic,Other
    }

    private PageId _pageId;

    private void OnGUI()
    {
        _pageId=(PageId)GUILayout.Toolbar((int) _pageId, Enum.GetNames(typeof(PageId)));
        if (_pageId == PageId.Basic)
        {
            one();
        }else if (_pageId == PageId.Other)
        {
            
        }
    }

    #region one

    private string TextField;
    private string TextArea;
    private string PasswordField = string.Empty;
    private Vector2 scrollVale;
    float mscrollValue=0;
    private void one()
    {
        scrollVale = GUILayout.BeginScrollView(scrollVale);
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

            GUILayout.Box("1");

            GUILayout.BeginHorizontal();
            {
                GUILayout.Label("水平滑动条");
                mscrollValue = GUILayout.HorizontalSlider(mscrollValue, 0, 1);
            }
            GUILayout.EndHorizontal();
        }
        GUILayout.EndScrollView(); 
    }
    #endregion
}