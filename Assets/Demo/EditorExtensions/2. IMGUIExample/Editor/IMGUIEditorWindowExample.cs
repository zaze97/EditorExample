using System;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    public class IMGUIEditorWindowExample : EditorWindow
    {
        [MenuItem("EditorExtensions/02.IMGUI/01.IMGUIEditorWindowExample")]
        static void OpenGUILayoutExample()
        {
            var window = GetWindow<IMGUIEditorWindowExample>();
            window.position = new Rect(100, 100, 640, 480);
                window.Show();
        }

        enum APIMode
        {
            GUILayout,
            GUI,
            EditorGUI,
            EditorGUILayout
        }
        
        enum PageId
        {
            Basic,
            Enabled,
            Rotate,
            Scale,
            Color,
        }

        private APIMode mCurrentAPIMode = APIMode.GUILayout;
        
        private PageId mCurrentPageId;

        private GUILayoutAPI mGUILayoutAPI = new GUILayoutAPI();

        private GUIAPI mGUIAPI = new GUIAPI();

        private EditorGUIAPI mEditorGUIAPI = new EditorGUIAPI();

        private EditorGUILayoutAPI mEditorGUILayoutAPI = new EditorGUILayoutAPI();
        
        private void OnGUI()
        {
            mCurrentAPIMode = (APIMode)GUILayout.Toolbar((int)mCurrentAPIMode,Enum.GetNames(typeof(APIMode)));
            
            mCurrentPageId = (PageId)GUILayout.Toolbar((int)mCurrentPageId,Enum.GetNames(typeof(PageId)));
            
            if (mCurrentPageId == PageId.Basic)
            {
                Basic();
            } else if (mCurrentPageId == PageId.Enabled)
            {
                Enabled();
            } else if (mCurrentPageId == PageId.Rotate)
            {
                Rotate();
            } else if (mCurrentPageId == PageId.Scale)
            {
                Scale();
            }
            else if (mCurrentPageId == PageId.Color)
            {
                Color();
            }
        }

        #region Basic

        void Basic()
        {
            if (mCurrentAPIMode == APIMode.GUILayout)
            {
                mGUILayoutAPI.Draw();
            } else if (mCurrentAPIMode == APIMode.GUI)
            {
                mGUIAPI.Draw();
            } else if (mCurrentAPIMode == APIMode.EditorGUI)
            {
                mEditorGUIAPI.Draw();
            }
            else
            {
                mEditorGUILayoutAPI.Draw();
            }
        }

        

        #endregion

        #region Color

        private bool mOpenColorEffect = false;

        void Color()
        {
            mOpenColorEffect = GUILayout.Toggle(mOpenColorEffect, "变换颜色");

            if (mOpenColorEffect)
            {
                GUI.color = UnityEngine.Color.yellow;
            }
            
            Basic();
        }
        

        #endregion

        #region Scale

        private bool mOpenScaleEffect = false;

        void Scale()
        {
            mOpenScaleEffect = GUILayout.Toggle(mOpenScaleEffect, "缩放效果");

            if (mOpenScaleEffect)
            {
                GUIUtility.ScaleAroundPivot(Vector2.one * 0.5f, Vector2.one * 200);
            }
            
            Basic();
            
        }

        #endregion

        #region Rotate

        private bool mOpenRotateEffect = false;

        void Rotate()
        {
            mOpenRotateEffect = GUILayout.Toggle(mOpenRotateEffect, "旋转效果");

            if (mOpenRotateEffect)
            {
                GUIUtility.RotateAroundPivot(45,Vector2.one * 200);
            }
            
            Basic();
            
        }

        #endregion
        #region Enabled

        private bool mEnableInteractive = true;

        void Enabled()
        {
            mEnableInteractive = GUILayout.Toggle(mEnableInteractive, "是否可交互");

            if (GUI.enabled != mEnableInteractive)
            {
                GUI.enabled = mEnableInteractive;
            }
            
            Basic();
        }
        
        #endregion
    }
}
