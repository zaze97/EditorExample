using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    public static class MenuItemExample
    {
        [MenuItem("EditorExtensions/01.Menu/01.Hello Editor")]
        static void HelloEditor()
        {
            Debug.Log("Hello Editor");
        }

        [MenuItem("EditorExtensions/01.Menu/02.Open Bilibili")]
        static void OpenBilibili()
        {
            Application.OpenURL("https://bilibili.com");
        }

        [MenuItem("EditorExtensions/01.Menu/03.Open PersistentDataPath")]
        static void OpenPersistentDataPath()
        {
            EditorUtility.RevealInFinder(Application.persistentDataPath);
        }

        [MenuItem("EditorExtensions/01.Menu/04.打开策划目录")]
        static void OpenDesignerFolder()
        {
            EditorUtility.RevealInFinder(Application.dataPath.Replace("Assets","Library"));
        }

        private static bool mOpenShotCut = false;

        [MenuItem("EditorExtensions/01.Menu/05.快捷键开关")]
        static void ToggleShotCut()
        {
            mOpenShotCut = !mOpenShotCut;
            
            Menu.SetChecked("EditorExtensions/01.Menu/05.快捷键开关",mOpenShotCut);
        }

        [MenuItem("EditorExtensions/01.Menu/06.Hello Editor _c")]
        static void HelloEditorWithShotCut()
        {
            EditorApplication.ExecuteMenuItem("EditorExtensions/01.Menu/01.Hello Editor");
        }
        
        [MenuItem("EditorExtensions/01.Menu/06.Hello Editor _c",validate = true)]
        static bool HelloEditorWithShotCutValidate()
        {
            return mOpenShotCut;
        }
        
        [MenuItem("EditorExtensions/01.Menu/07.Open Bilibili %e")]
        static void OpenBilibiliWithShotCut()
        {
            EditorApplication.ExecuteMenuItem("EditorExtensions/01.Menu/02.Open Bilibili");
        }
        
        [MenuItem("EditorExtensions/01.Menu/07.Open Bilibili %e",validate = true)]
        static bool OpenBilibiliWithShotCutValidate()
        {
            return mOpenShotCut;
        }
        
        [MenuItem("EditorExtensions/01.Menu/08.Open PersistentDataPath %#t")]
        static void OpenPersistentDataPathWithShotCut()
        {
            EditorApplication.ExecuteMenuItem("EditorExtensions/01.Menu/03.Open PersistentDataPath");
        }
        
        [MenuItem("EditorExtensions/01.Menu/08.Open PersistentDataPath %#t",validate = true)]
        static bool OpenPersistentDataPathWithShotCutValidate()
        {
            return mOpenShotCut;
        }
        
        [MenuItem("EditorExtensions/01.Menu/09.打开策划目录 &r")]
        static void OpenDesignerFolderWithShotCut()
        {
            EditorApplication.ExecuteMenuItem("EditorExtensions/01.Menu/04.打开策划目录");
        }
        
        [MenuItem("EditorExtensions/01.Menu/09.打开策划目录 &r",validate = true)]
        static bool OpenDesignerFolderWithShotCutValidate()
        {
            return mOpenShotCut;
        }

        
        static MenuItemExample()
        {
            Menu.SetChecked("EditorExtensions/01.Menu/05.快捷键开关",mOpenShotCut);
        }
    }
}