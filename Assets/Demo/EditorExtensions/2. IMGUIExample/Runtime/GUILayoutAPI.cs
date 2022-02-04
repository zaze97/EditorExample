using UnityEngine;

namespace EditorExtensions
{
    public class GUILayoutAPI
    {
        #region Basic
        private string mTextFieldValue;
        private string mTextAreaValue;
        private string mPasswordFieldValue = string.Empty;
        private Vector2 mScrollPosition;
        private float mSliderValue;
        private int mToolbarIndex;
        private bool mToggleValue;
        private int mSelectedGridIndex;
        
        public void Draw()
        {
            GUILayout.Label("Label：Hello IMGUI");

            mScrollPosition = GUILayout.BeginScrollView(mScrollPosition);
            {
                GUILayout.BeginVertical("box");
                {
                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("TextField");
                        mTextFieldValue = GUILayout.TextField(mTextFieldValue);
                    }
                    GUILayout.EndHorizontal();

                    GUILayout.Space(100);
                    
                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("TextArea");
                        mTextAreaValue = GUILayout.TextArea(mTextAreaValue);
                    }
                    GUILayout.EndHorizontal();


                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("PasswordField");
                        mPasswordFieldValue = GUILayout.PasswordField(mPasswordFieldValue, '*');
                    }
                    GUILayout.EndHorizontal();

                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("Button");
                        
                        // GUILayout.FlexibleSpace();
                        
                        if (GUILayout.Button("Button",GUILayout.MinWidth(100),GUILayout.MinHeight(100),GUILayout.MaxWidth(150),GUILayout.MaxHeight(150)))
                        {
                            Debug.Log("Button Clicked");
                        }
                    }
                    GUILayout.EndHorizontal();

                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("RepeatButton");
                        if (GUILayout.RepeatButton("RepeatButton",GUILayout.Width(150),GUILayout.Height(150)))
                        {
                            Debug.Log("RepeatButton Clicked");
                        }
                    }
                    GUILayout.EndHorizontal();

                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("Box");
                        GUILayout.Box("AutoLayout Box");
                    }
                    GUILayout.EndHorizontal();
                    
                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("HorizontalSlider");
                        mSliderValue = GUILayout.HorizontalSlider(mSliderValue, 0, 1);
                    }
                    GUILayout.EndHorizontal();
                    
                    GUILayout.Label("VerticalSlider");
                    mSliderValue = GUILayout.VerticalSlider(mSliderValue, 0, 1);
                    
                    GUILayout.BeginArea(new Rect(0,0,100,100));
                    {
                        GUI.Label(new Rect(0,0,20,20),"1");
                    }
                    GUILayout.EndArea();

                    GUILayout.Window(1, new Rect(0, 0, 100, 100), id =>
                    {

                    }, "2");

                    mToolbarIndex = GUILayout.Toolbar(mToolbarIndex, new[] { "1","2","3","4","5" });
                    mToggleValue = GUILayout.Toggle(mToggleValue, "Toggle");

                    mSelectedGridIndex = GUILayout.SelectionGrid(mSelectedGridIndex, new[]
                    {
                        "1",
                        "2",
                        "3",
                        "4",
                        "5"
                    }, 3);
                }
                GUILayout.EndVertical();
            }
            GUILayout.EndScrollView();
        }
        #endregion
    }
}