using System;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEditor.EditorTools;
using UnityEngine;

namespace EditorExtensions
{
    public class EditorGUILayoutAPI
    {
        private BuildTargetGroup mBuildTargetGroupValue;

        private AnimBool mAnimBool = new AnimBool(false);
        

        private bool mFoldOutGroup = false;

        private bool mGroupValue = false;
        private bool mToggle1Value = false;
        private bool mToggle2Value = true;

        public void Draw()
        {
            mAnimBool.target = EditorGUILayout.ToggleLeft("Open Fade Group", mAnimBool.target);

            mFoldOutGroup = EditorGUILayout.BeginFoldoutHeaderGroup(mFoldOutGroup, "FoldOut");
            if (mFoldOutGroup)
            {
                EditorGUILayout.BeginFadeGroup(mAnimBool.faded);
                if (mAnimBool.target)
                {
                    mBuildTargetGroupValue = EditorGUILayout.BeginBuildTargetSelectionGrouping();

                    EditorGUILayout.EndBuildTargetSelectionGrouping();
                }

                EditorGUILayout.EndFadeGroup();
            }

            EditorGUILayout.EndFoldoutHeaderGroup();


            mGroupValue = EditorGUILayout.BeginToggleGroup("全部设置", mGroupValue);

            mToggle1Value = EditorGUILayout.Toggle(mToggle1Value);
            mToggle2Value = EditorGUILayout.Toggle(mToggle2Value);

            EditorGUILayout.EndToggleGroup();

        }
    }
}