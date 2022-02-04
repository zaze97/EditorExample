using System;

namespace EditorWindows
{
    public class CustomEditorWindowAttribute:Attribute
    {
        public int RenderOrder { get; private set; }

        public CustomEditorWindowAttribute(int order=-1)
        {
            RenderOrder = order;
        }
    }
}