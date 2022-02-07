using UnityEngine;

namespace EditorFramework
{
    public class  Label:  GUIBase
    {
        private string mText;
        public Label(string text)
        {
            mText = text;
        }

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);
            GUILayout.Label(mText);
        }

        protected override void OnDispose()
        {
            mText = null;
        }
    }
}