using UnityEngine;

namespace Editor._01.MenuItem.WindowsExample
{
    public class GUILayoutAPI:API
    {
         #region Basic
        
            private string TextField;
            private string TextArea;
            private string PasswordField = string.Empty;
            private Vector2 scrollVale;
            float mscrollValue=0;
            private  Rect windowRect = new Rect(0, 40, 200, 300);
            public void Draw()
            {
             //   windowRect= GUILayout.Window(1,windowRect, DrawGUI, "My Window" );
             DrawGUI(1);
            }

            private void DrawGUI(int id)
            {
                 scrollVale = GUILayout.BeginScrollView(scrollVale);
                {
                    GUILayout.Label("窗口打开");
                    GUILayout.Label("--------输入框--------");
                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("TextField");
                        TextField = GUILayout.TextField(TextField);
                    }
                    GUILayout.EndHorizontal();
                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("TextArea");
                        TextArea = GUILayout.TextArea(TextArea);
                    }
                    GUILayout.EndHorizontal();
                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("PasswordField");
                        PasswordField = GUILayout.PasswordField(PasswordField, '*');
                    }
                    GUILayout.EndHorizontal();
                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("Button(按下执行一次)");
                        if (GUILayout.Button("Button"))
                        {
                            Debug.Log("Button按钮按下");
                        }
                    }
                    GUILayout.EndHorizontal();
                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("RepeatButton(按下和抬起都会执行一次)");
                        if (GUILayout.RepeatButton("RepeatButton"))
                        {
                            Debug.Log("RepeatButton按钮按下");
                        }
                    }
                    GUILayout.EndHorizontal();
        
                    GUILayout.Box("1");
        
                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("水平滑动条");
                        mscrollValue = GUILayout.HorizontalSlider(mscrollValue, 0, 1);
                    }
                    GUILayout.EndHorizontal();
                }
                GUILayout.EndScrollView(); 
            }
            #endregion
    }
}