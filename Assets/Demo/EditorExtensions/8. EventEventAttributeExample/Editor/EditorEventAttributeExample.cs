using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace EditorExtensions
{
    [InitializeOnLoad]
    public class EditorEventAttributeExample 
    {
        static EditorEventAttributeExample()
        {
            Debug.Log("EditorEventAttributeExample");
        }

        [InitializeOnLoadMethod]
        static void InitializeOnLoadMethod()
        {
            Debug.Log("InitializeOnLoadMethod");
        }

        [DidReloadScripts()]
        static void OnScriptReload()
        {
            Debug.Log("脚本加载完毕");
        }

        [PostProcessScene]
        public static void OnPostProcessScene()
        {
            Debug.Log("OnPostProcessScene");
        }

        [PostProcessBuild]
        public static void OnPostProcessBuild(BuildTarget target, string pathToBuiltProject)
        {
            Debug.Log("OnPostProcessBuild");
        }

        [OnOpenAsset(1)]
        public static bool OpenAsset(int instanceID, int line)
        {
            var name = EditorUtility.InstanceIDToObject(instanceID).name;
            Debug.Log("Open Asset step:1 (" + name + ")");
            return false;
        }
        
        [OnOpenAsset(2)]
        public static bool OpenAsset2(int instanceID, int line)
        {
            var name = EditorUtility.InstanceIDToObject(instanceID).name;
            Debug.Log("Open Asset step:2 (" + name + ")");
            return false;
        }
    }
}