using UnityEngine;

namespace EditorExtensions
{
    public class IMGUIRuntimeExample : MonoBehaviour
    {
        private GUILayoutAPI mGUILayoutAPI = new GUILayoutAPI();
        private GUIAPI mGUIAPI = new GUIAPI();

        private int mIndex = 0;
        
        private void OnGUI()
        {
            mIndex = GUILayout.Toolbar(mIndex, new[] { "GUILayoutAPI", "GUIAPI" });

            if (mIndex == 0)
            {
                mGUILayoutAPI.Draw();
            }
            else
            {
                mGUIAPI.Draw();
            }
        }
    }
}