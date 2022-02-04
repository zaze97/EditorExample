using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using EditorFramework;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{

    public class SearchField : GUIBase
    {

        private int mContentIndex;
        private string mSearchContent;
        private string[] mSearchableContents;
        private MethodInfo mDrawAPI;


        public event Action<int> OnModeChanged;
        public event Action<string> OnValueChanged;
        public event Action<string> OnEndEdit;
        
        public SearchField(string searchContent, string[] searchableContents, int contentIndex)
        {
            mContentIndex = contentIndex;
            mSearchContent = searchContent;
            mSearchableContents = searchableContents;

            mDrawAPI = typeof(EditorGUI).GetMethod("ToolbarSearchField",
                BindingFlags.NonPublic | BindingFlags.Static,
                null,
                new Type[]
                {
                    typeof(int),
                    typeof(Rect),
                    typeof(string[]),
                    typeof(int).MakeByRefType(),
                    typeof(string)
                },
                null);
        }

        private int mControlId;
        
        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);

            if (mDrawAPI != null)
            {
                mControlId = GUIUtility.GetControlID("EditorSearchField".GetHashCode(), FocusType.Keyboard, position);

                int mode = mContentIndex;
                object[] args = new object[] { mControlId, position, mSearchableContents, mode, mSearchContent };
                string newSearchContent = mDrawAPI.Invoke(null, args) as string;
                if ((int)args[3] != mContentIndex)
                {
                    mContentIndex = (int)args[3];
                    OnModeChanged?.Invoke(mContentIndex);
                }

                if (newSearchContent != mSearchContent)
                {
                    mSearchContent = newSearchContent;
                    OnValueChanged?.Invoke(mSearchContent);
                }

                Event e = Event.current;
                if ((e.keyCode == KeyCode.Return || e.keyCode == KeyCode.Escape || e.character == '\n'))
                {
                    if (GUIUtility.keyboardControl == mControlId)
                    {
                        GUIUtility.keyboardControl = -1;
                        if (e.type != EventType.Repaint && e.type != EventType.Layout)
                        {
                            e.Use();
                        }
                        OnEndEdit?.Invoke(mSearchContent);
                    }
                }

            }
        }


        protected override void OnDispose()
        {

        }
    }
}