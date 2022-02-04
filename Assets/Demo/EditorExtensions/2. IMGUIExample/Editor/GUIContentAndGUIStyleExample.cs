using System;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    public class GUIContentAndGUIStyleExample : EditorWindow
    {
        [MenuItem("EditorExtensions/02.IMGUI/02.GUIContentAndGUIStyle")]
        static void Open()
        {
            GetWindow<GUIContentAndGUIStyleExample>()
                .Show();
        }
        
        enum Mode
        {
            GUIContent,
            GUIStyle
        }

        private int mToolbarIndex;

        private GUIStyle mBoxStyle = "box";

        private Lazy<GUIStyle> mFontStyle = new Lazy<GUIStyle>(() =>
        {
            var retStyle = new GUIStyle("label");
            retStyle.fontSize = 30;
            retStyle.fontStyle = FontStyle.BoldAndItalic;
            retStyle.normal.textColor = Color.green;
            retStyle.hover.textColor = Color.blue;
            retStyle.focused.textColor = Color.red;
            retStyle.active.textColor = Color.cyan;
            retStyle.normal.background = Texture2D.whiteTexture;
            
            return retStyle;
        });
        
        private Lazy<GUIStyle> mButtonStyle = new Lazy<GUIStyle>(() =>
        {
            var retStyle = new GUIStyle(GUI.skin.button);
            retStyle.fontSize = 30;
            retStyle.fontStyle = FontStyle.BoldAndItalic;
            retStyle.normal.textColor = Color.green;
            retStyle.hover.textColor = Color.blue;
            retStyle.focused.textColor = Color.red;
            retStyle.active.textColor = Color.cyan;
            retStyle.normal.background = Texture2D.whiteTexture;
            
            return retStyle;
        });

        

        private void OnGUI()
        {
            mToolbarIndex = GUILayout.Toolbar(mToolbarIndex, Enum.GetNames(typeof(Mode)));

            if (mToolbarIndex == (int)Mode.GUIContent)
            {
                GUILayout.Label("把鼠标放在我身上");
                GUILayout.Label(new GUIContent("把鼠标放在我身上"));
                GUILayout.Label(new GUIContent("把鼠标放在我身上","已经放好了 Yeah"));
                GUILayout.Label(new GUIContent("把鼠标放在我身上",Texture2D.whiteTexture));
                GUILayout.Label(new GUIContent("把鼠标放在我身上",Texture2D.whiteTexture,"这个也放好了 Yeah"));
            }
            else
            {
                GUILayout.Label("Style of default");
                GUILayout.Label("Style of box",mBoxStyle);
                GUILayout.Label("Style font",mFontStyle.Value);
                if (GUILayout.Button("Button font", mButtonStyle.Value))
                {
                    Debug.Log("Print Button");
                }
            }
        }
    }
}