
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    public class EditorGUIAPI
    {
        private Rect mLabelRect = new Rect(10, 60, 200, 20);
        private Rect mTextFieldRect = new Rect(10, 90, 200, 20);
        private Rect mTextAreaRect = new Rect(10, 120, 200, 40);
        private Rect mPasswordFieldRect = new Rect(10, 170, 200, 20);
        private Rect mDropdownButtonRect = new Rect(10, 200, 200, 20);
        private Rect mLinkedButtonRect = new Rect(10, 230, 200, 20);
        private Rect mToggleRect = new Rect(10, 260, 200, 20);
        private Rect mToggleLeftRect = new Rect(10, 290, 200, 20);
        private Rect mHelpBoxRect = new Rect(10, 320, 200, 20);
        private Rect mColorFieldRect = new Rect(10, 350, 200, 20);
        private Rect mBoundsFieldRect = new Rect(10, 380, 200, 20);
        private Rect mBoundsIntFieldRect = new Rect(10, 410, 200, 20);
        private Rect mCurveFieldRect = new Rect(10, 440, 200, 20);
        private Rect mDelayedDoubleFieldRect = new Rect(10, 470, 200, 20);
        private Rect mDoubleFieldRect = new Rect(10, 500, 200, 20);
        private Rect mEnumFlagsFieldRect = new Rect(10, 530, 200, 20);
        private Rect mEnumPopRect = new Rect(10, 560, 200, 20);
        private Rect mGradientFieldRect = new Rect(210, 90, 200, 20);

        private bool mDisabledGroupValue = false;
        private string mTextFieldValue;
        private string mTextAreaValue;
        private string mPasswordFieldValue = string.Empty;
        private bool mToggleValue = false;
        private Color mColorFieldValue;
        private Bounds mBoundsFieldValue;
        private BoundsInt mBoundsIntFieldValue;
        private AnimationCurve mCurveFieldValue = new AnimationCurve();
        private double mDoubleFieldvalue;

        private Gradient mGradient = new Gradient();
        private enum EnumFlagsFieldValue
        {
            A = 1,
            B,
            C
        }

        private EnumFlagsFieldValue mEnumFlagsFieldValue;

        private bool mFoldOutValue = true;
        public void Draw()
        {
            mDisabledGroupValue = EditorGUILayout.Toggle("Disable Group", mDisabledGroupValue);

            mFoldOutValue = EditorGUI.Foldout(new Rect(210, 60, 300, 20),mFoldOutValue,"折叠");
            if (mFoldOutValue)
            {
                EditorGUI.BeginDisabledGroup(mDisabledGroupValue);
                {
                    EditorGUI.LabelField(mLabelRect, "LabelField");
                    mTextFieldValue = EditorGUI.TextField(mTextFieldRect, mTextFieldValue);
                    mTextAreaValue = EditorGUI.TextArea(mTextAreaRect, mTextAreaValue);
                    mPasswordFieldValue = EditorGUI.PasswordField(mPasswordFieldRect, mPasswordFieldValue);
                    if (EditorGUI.DropdownButton(mDropdownButtonRect, new GUIContent("123", ""), FocusType.Keyboard))
                    {
                        Debug.Log("DropdownButton Clicked");
                    }

                    // if (EditorGUI.LinkButton(mLinkedButtonRect, "link button"))
                    // {
                    //     Debug.Log("Link Button Clicked");
                    // }

                    mToggleValue = EditorGUI.Toggle(mToggleRect, mToggleValue);
                    mToggleValue = EditorGUI.ToggleLeft(mToggleLeftRect, "打开/关闭", mToggleValue);

                    EditorGUI.HelpBox(mHelpBoxRect, "123123123", MessageType.Error);

                    mColorFieldValue = EditorGUI.ColorField(mColorFieldRect, mColorFieldValue);
                    mBoundsFieldValue = EditorGUI.BoundsField(mBoundsFieldRect, mBoundsFieldValue);
                    mBoundsIntFieldValue = EditorGUI.BoundsIntField(mBoundsIntFieldRect, mBoundsIntFieldValue);
                    mCurveFieldValue = EditorGUI.CurveField(mCurveFieldRect, mCurveFieldValue);
                    mDoubleFieldvalue = EditorGUI.DelayedDoubleField(mDelayedDoubleFieldRect, mDoubleFieldvalue);
                    mDoubleFieldvalue = EditorGUI.DoubleField(mDoubleFieldRect, mDoubleFieldvalue);
                    mEnumFlagsFieldValue =
                        (EnumFlagsFieldValue)EditorGUI.EnumFlagsField(mEnumFlagsFieldRect, mEnumFlagsFieldValue);
                    mEnumFlagsFieldValue = (EnumFlagsFieldValue)EditorGUI.EnumPopup(mEnumPopRect, mEnumFlagsFieldValue);

                    mGradient = EditorGUI.GradientField(mGradientFieldRect, mGradient);
                }
                EditorGUI.EndDisabledGroup();
            }
        }
    }
}