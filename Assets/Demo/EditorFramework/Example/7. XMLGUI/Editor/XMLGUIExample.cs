using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    [CustomEditorWindow(7)]
    public class XMLGUIExample : EditorWindow
    {
        private const string XMLFilePath = "Assets/EditorFramework/Example/7. XMLGUI/Editor/GUIExample.xml";

        private string mXMLContent;

        private XMLGUI mXmlgui;
        private void OnEnable()
        {
            
            var xmlFileAsset = AssetDatabase.LoadAssetAtPath<TextAsset>(XMLFilePath);
            mXMLContent = xmlFileAsset.text;

            mXmlgui = new XMLGUI();
            mXmlgui.ReadXML(mXMLContent);
            
            
            mXmlgui.GetGUIBaseById<XMLGUILayoutButton>("loginButton").OnClick += () =>
            {
                Debug.Log("按钮点击了");

                mXmlgui.GetGUIBaseById<XMLGUILayoutLabel>("label1").Text = "1";
                mXmlgui.GetGUIBaseById<XMLGUILayoutLabel>("label2").Text = "2";
                mXmlgui.GetGUIBaseById<XMLGUILayoutLabel>("label3").Text = "3";
                // mXmlgui.GetGUIBaseById<XMLGUITextField>("username").Text = "凉鞋";
                // mXmlgui.GetGUIBaseById<XMLGUITextArea>("description").Text = "本课程的作者，各种作者";
            };
        }

        private void OnGUI()
        {
            mXmlgui.Draw();
        }
    }
}