using UnityEngine;

namespace Editor._01.MenuItem.WindowsExample
{
    public class GUIAPI :API
    {
        Rect mlablRect=new Rect(0,60,200,20);
        Rect mfildRect=new Rect(0,90,200,20);
        Rect mareaRect=new Rect(0,120,200,90);
        private string textField;
        private string textArea;
        public void Draw()
        {
            GUI.Label(mlablRect,"Label:Hello GUI API");
            textField=GUI.TextField(mfildRect,textField);
            textArea=GUI.TextArea(mareaRect,textArea);
        }
    }
}