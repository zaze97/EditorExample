using System;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    [CustomEditorWindow(8)]
    public class SearchFieldExample : EditorWindow
    {
        private SearchField mSearchField;

        private string mSearchContent = "";
        private string[] mSearchableContents = new[] { "mode1", "mode2", "mode3" };

        private void OnEnable()
        {
            mSearchField = new SearchField(mSearchContent, mSearchableContents, 0);
            mSearchField.OnValueChanged += SearchFieldOnOnValueChanged;
            mSearchField.OnModeChanged += SearchFieldOnOnModeChanged;
        }

        private void SearchFieldOnOnModeChanged(int obj)
        {
            Debug.Log(obj);
        }

        private void SearchFieldOnOnValueChanged(string obj)
        {
            Debug.Log(obj);
        }


        private void OnGUI()
        {
            GUILayout.Label("SearchField");
            mSearchField.OnGUI(EditorGUILayout.GetControlRect(GUILayout.Height(20)));
        }
    }
}