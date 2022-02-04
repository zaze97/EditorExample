using UnityEditor;
using UnityEngine;

namespace Editor._01.MenuItem.WindowsExample
{
    public class EditorGUIAPI : API
    {
        #region Basic

        private bool mDisabledGroupValue;
        
        public void Draw()
        {
            mDisabledGroupValue = EditorGUILayout.Toggle("打开", mDisabledGroupValue);
            EditorGUI.BeginDisabledGroup(mDisabledGroupValue == false);
            {
                EditorGUILayout.LabelField("LabelField");
            }
            EditorGUI.EndDisabledGroup();
        }

        #endregion
    }
}