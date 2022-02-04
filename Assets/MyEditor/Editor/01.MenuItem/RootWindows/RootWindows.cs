using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EditorWindows;
using UnityEditor;
using UnityEngine;

public class RootWindows : EditorWindow
{
    [MenuItem("EditorFramework/Open")]
    static void Open()
    {
        GetWindow<RootWindows>().Show();
    }

    private IEnumerable<Type> editorWindowTypes = default;

    private void OnEnable()
    {
        var editorWindowType = typeof(EditorWindow);
        var m_Parent = editorWindowType.GetField("m_Parent", BindingFlags.Instance | BindingFlags.NonPublic);

        editorWindowTypes = editorWindowType.GetSubTypesWithClassAttribute<CustomEditorWindowAttribute>()
            .OrderBy(type => type.GetCustomAttribute<CustomEditorWindowAttribute>().RenderOrder);//对顺序进行排序用OrderBy
        // foreach (var windowType in editorWindowTypes)
        // {
        //    Debug.Log(windowType.Name);
        // }
    }

    private void OnGUI()
    {
        foreach (var editorWindowType in editorWindowTypes) //绘制出所有窗口的打开按钮
        {
            GUILayout.BeginHorizontal("Box");
            {
                GUILayout.Label(editorWindowType.Name);
                if (GUILayout.Button("Open", GUILayout.Width(80)))
                {
                    GetWindow(editorWindowType).Show();
                }
            }
            GUILayout.EndHorizontal();
        }
    }
}