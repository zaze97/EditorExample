using System;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    [CustomEditorWindow(6)]
    public class SplitViewExample : EditorWindow
    {
        private SplitView mSplitView;

        private void OnEnable()
        {
            mSplitView = new SplitView();
            mSplitView.FirstArea += SplitViewOnFirstArea;
            mSplitView.SecondArea += SplitViewOnSecondArea;
        }

        private void SplitViewOnFirstArea(Rect obj)
        {
            obj.DrawOutline(Color.green);
            GUI.Box(obj, "First");
        }

        private void SplitViewOnSecondArea(Rect obj)
        {
            obj.DrawOutline(Color.green);
            GUI.Box(obj, "Second");
        }

        private void OnGUI()
        {
            mSplitView.OnGUI(this.LocalPosition().Zoom(AnchorType.MiddleCenter, -10));
        }
    }
}