using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{

    [CustomEditorWindow(3)]
    public class TypeExExample : EditorWindow
    {
        public class DescriptionBase
        {
            public virtual string Description { get; set; }
        }
        
        public class MyDescription : DescriptionBase
        {
            public override string Description { get; set; } = "这是一个描述";
        }
        
        
        [MyDesc("TypeB")]
        public class MyDescriptionB : DescriptionBase
        {
            public override string Description { get; set; } = "这是一个描述B";
        }
        
        public class MyDescAttribute : Attribute
        {
            public string Type;

            public MyDescAttribute(string type = "")
            {
                Type = type;
            }
        }
        
        private IEnumerable<Type> mDescriptionTypes;
        private IEnumerable<Type> mDescriptionTypesWithAttribute;
        private void OnEnable()
        {
            mDescriptionTypes = typeof(DescriptionBase).GetSubTypesInAssemblies();
            mDescriptionTypesWithAttribute = typeof(DescriptionBase).GetSubTypesWithClassAttributeInAssemblies<MyDescAttribute>();
        }

        private void OnGUI()
        {
            GUILayout.Label("Types");
            foreach (var descriptionType in mDescriptionTypes)
            {
                GUILayout.BeginHorizontal("box");
                GUILayout.Label(descriptionType.Name);
                GUILayout.EndHorizontal();
            }
            
            GUILayout.Label("With Attribute");
            foreach (var descriptionType in mDescriptionTypesWithAttribute)
            {
                GUILayout.BeginHorizontal("box");
                GUILayout.Label(descriptionType.Name);
                GUILayout.Label(descriptionType.GetCustomAttribute<MyDescAttribute>().Type);
                GUILayout.EndHorizontal();
            }
        }
    }
}