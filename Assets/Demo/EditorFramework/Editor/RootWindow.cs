using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    public class RootWindow : EditorWindow
    {
        [MenuItem("EditorFramework/Open %#e")]
        static void Open()
        {
            GetWindow<RootWindow>().Show();
        }

        private IEnumerable<Type> mEditorWindowTypes;
        
        private void OnEnable()
        {
            mEditorWindowTypes =
                typeof(EditorWindow)
                    .GetSubTypesWithClassAttributeInAssemblies<CustomEditorWindowAttribute>()
                    .OrderBy(type => type.GetCustomAttribute<CustomEditorWindowAttribute>().RenderOrder);
        }

        private void OnGUI()
        {
            foreach (var editorWindowType in mEditorWindowTypes)
            {
                GUILayout.BeginHorizontal("box");
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
}