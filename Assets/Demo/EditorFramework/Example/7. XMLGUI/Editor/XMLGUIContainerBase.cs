using System.Xml;

namespace EditorFramework
{
    public abstract class XMLGUIContainerBase : XMLGUIBase
    {
        
        private XMLGUI mXmlgui = new XMLGUI();

        public XMLGUI XMLGUI
        {
            get { return mXmlgui; }
        }

        public override void ParseXML(XmlElement xmlElement ,XMLGUI rootXMLGUI)
        {
            base.ParseXML(xmlElement,rootXMLGUI);

            mXmlgui.ChildElements2GUIBases(xmlElement,rootXMLGUI);
        }
        
        protected override void OnDispose()
        {
            
        }
    }
}