using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace EditorFramework
{
    public class XMLGUI
    {
        private List<XMLGUIBase> mGUIBases = new List<XMLGUIBase>();
        private Dictionary<string, XMLGUIBase> mGUIBaseForId = new Dictionary<string, XMLGUIBase>();

        public void Draw()
        {
            foreach (var xmlguiBase in mGUIBases)
            {
                xmlguiBase.Draw();
            }
        }

        public T GetGUIBaseById<T>(string id) where T : XMLGUIBase
        {
            XMLGUIBase t = default;
            if (mGUIBaseForId.TryGetValue(id, out t))
            {
                return t as T;
            }
            else
            {
                return default;
            }
        }

        private Dictionary<string, Func<XMLGUIBase>> mFactoriesForGUIBaseNames =
            new Dictionary<string, Func<XMLGUIBase>>()
            {
                { "Label", () => new XMLGUILabel() },
                { "TextField", () => new XMLGUITextField() },
                { "TextArea", () => new XMLGUITextArea() },
                { "Button", () => new XMLGUIButton() },
                { "LayoutLabel", () => new XMLGUILayoutLabel() },
                { "LayoutButton", () => new XMLGUILayoutButton() },
                { "LayoutHorizontal", () => new XMLGUILayoutHorizontal() },
                { "LayoutVertical", () => new XMLGUILayoutVertical() }
            };

        public void ReadXML(string xml)
        {
            var doc = new XmlDocument();
            doc.LoadXml(xml);
            var rootNode = doc.SelectSingleNode("GUI");
            ChildElements2GUIBases(rootNode as XmlElement, this);
        }

        public void ChildElements2GUIBases(XmlElement rootElement, XMLGUI rootXMLGUI)
        {
            Func<XMLGUIBase> xmlGUIBaseFactory = default;
            XMLGUIBase xmlGUIBase = default;

            foreach (XmlElement rootNodeChildNode in rootElement.ChildNodes)
            {
                if (mFactoriesForGUIBaseNames.TryGetValue(rootNodeChildNode.Name, out xmlGUIBaseFactory))
                {
                    xmlGUIBase = xmlGUIBaseFactory();
                    xmlGUIBase.ParseXML(rootNodeChildNode, rootXMLGUI);
                    AddGUIBase(xmlGUIBase, rootXMLGUI);
                }
            }
        }

        void AddGUIBase(XMLGUIBase guiBase, XMLGUI rootXMLGUI)
        {
            mGUIBases.Add(guiBase);
            if (!string.IsNullOrEmpty(guiBase.Id))
            {
                mGUIBaseForId.Add(guiBase.Id, guiBase);

                if (rootXMLGUI == this)
                {
                }
                else
                {
                    rootXMLGUI.mGUIBaseForId.Add(guiBase.Id, guiBase);
                }
            }
        }
    }
}