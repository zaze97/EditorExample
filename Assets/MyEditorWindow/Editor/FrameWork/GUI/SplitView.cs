using System;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    public class SplitView : GUIBase
    {
        public SplitType SplitType = SplitType.Vertical;

        public event Action<Rect> FirstArea, SecondArea;
        public event Action OnBeginResize, OnEndResize;

        public float SplitSize = 200;
        public float MinSize = 100;
        private bool mResizing;

        public bool Dragging
        {
            get { return mResizing; }
            set
            {
                if (mResizing != value)
                {
                    mResizing = value;
                    if (value)
                    {
                        if (OnBeginResize != null)
                        {
                            OnBeginResize();
                        }
                    }
                    else
                    {
                        if (OnEndResize != null)
                        {
                            OnEndResize();
                        }
                    }
                }
            }
        }

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);

            var rects = position.Split(SplitType, SplitSize, 4);
            var mid = position.SplitRect(SplitType, SplitSize, 4);

            // 绘制左边区域
            if (FirstArea != null)
            {
                FirstArea(rects[0]);
            }

            // 绘制右边区域
            if (SecondArea != null)
            {
                SecondArea(rects[1]);
            }
            //绘制中间的线
            EditorGUI.DrawRect(mid.Zoom(AnchorType.MiddleCenter, -2), Color.gray);

            //在中间线进行拖拽
            var e = Event.current;
            if (mid.Contains(e.mousePosition))
            {
                if (SplitType == SplitType.Vertical)
                {
                    EditorGUIUtility.AddCursorRect(mid, MouseCursor.ResizeHorizontal);
                }
                else
                {
                    EditorGUIUtility.AddCursorRect(mid, MouseCursor.ResizeVertical);
                }
            }

            switch (e.type)
            {
                case EventType.MouseDown:
                    if (mid.Contains(e.mousePosition))
                    {
                        Dragging = true;
                    }

                    break;
                case EventType.MouseDrag:
                    if (Dragging)
                    {
                        if (SplitType == SplitType.Vertical)
                        {
                            SplitSize += e.delta.x;

                            SplitSize = Mathf.Clamp(SplitSize, MinSize, position.width - MinSize);
                        }
                        else
                        {
                            SplitSize += e.delta.y;

                            SplitSize = Mathf.Clamp(SplitSize, MinSize, position.height - MinSize);
                        }

                        e.Use();
                    }

                    break;
                case EventType.MouseUp:
                    if (Dragging)
                    {
                        Dragging = false;
                    }

                    break;
            }
        }

        protected override void OnDispose()
        {
            FirstArea = null;
            SecondArea = null;
            OnBeginResize = null;
            OnEndResize = null;
        }
    }
}