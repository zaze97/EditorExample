using UnityEditor;
using UnityEngine;

public class MenuItemExample : MonoBehaviour
{
        [MenuItem("Editor/01.MenuItem/Hello")]
        static void OpenMenuItem()
        {
                Debug.Log("利用MenuItem执行方法");
        }
        [MenuItem("Editor/01.MenuItem/OpenURL")]
        static void OpenMenuItemURL()
        {
               Application.OpenURL("https://www.yuque.com/poetrybook/mug2bu/kvexsr");
        }
        [MenuItem("Editor/01.MenuItem/OpenURL",validate = true)]
        static bool OpenMenuItemURLToValidate()
        {
            return mOpenShotCut;
        }
        [MenuItem("Editor/01.MenuItem/OpenPersistentDataPath")]
        static void OpenMenuItemPath()
        {
            UnityEditor.EditorUtility.RevealInFinder(Application.persistentDataPath);
        }
        [MenuItem("Editor/01.MenuItem/OpenPersistentDataPath",validate = true)]
        static bool OpenMenuItemPathToValidate()
        {
            return mOpenShotCut;
        }
        private static bool mOpenShotCut = false;
        [MenuItem("Editor/01.MenuItem/快捷键开关")]
        static void ToggleShotCut()
        {
            mOpenShotCut = !mOpenShotCut;
            Menu.SetChecked("Editor/01.MenuItem/快捷键开关",mOpenShotCut);
        }
        
        [MenuItem("Editor/01.MenuItem/OpenPersistentDataPathKey %t")]
        static void OpenMenuItemPathKey()
        {
            EditorApplication.ExecuteMenuItem("Editor/01.MenuItem/OpenPersistentDataPath");
        }
}
