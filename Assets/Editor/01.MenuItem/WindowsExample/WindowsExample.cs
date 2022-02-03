using System;
using Editor._01.MenuItem.WindowsExample;
using UnityEditor;
using UnityEngine;

public class WindowsExample : EditorWindow
{
    [MenuItem("Editor/02.EditorWindows/Open")]
    static void OpenEditorWindows()
    {
        GetWindow<WindowsExample>().Show();
    }
    public enum APIMode
    {
        GUILayout,
        GUI,
        EditorGUI
    }
    public enum PageId
    {
        Basic,Enabled,Rotate,Scale,Color
    }
    private APIMode _apiMode;
    private PageId _pageId;
    private API _api;
    private GUILayoutAPI _guiLayoutApi=new GUILayoutAPI();
    private GUIAPI _guiApi=new GUIAPI();
    private EditorGUIAPI _editorGuiApi=new EditorGUIAPI();
    private void OnGUI()
    {
        _apiMode=(APIMode)GUILayout.Toolbar((int) _apiMode, Enum.GetNames(typeof(APIMode)));
        _pageId=(PageId)GUILayout.Toolbar((int) _pageId, Enum.GetNames(typeof(PageId)));
        SwitchAPI();
        if (_pageId == PageId.Basic)
        {
            _api.Draw();
        }else if (_pageId == PageId.Enabled)
        {
            GUI_Enabled();
        }
        else if (_pageId == PageId.Rotate)
        {
            GUI_Rotate();
        } else if (_pageId == PageId.Scale)
        {
            GUI_Scale();
        }else if (_pageId == PageId.Color)
        {
            GUI_Color();
        }
    }

    private void SwitchAPI()
    {
        if(_apiMode==APIMode.GUILayout)
            _api=_guiLayoutApi;
        else if(_apiMode==APIMode.GUI)
            _api=_guiApi;
        else if(_apiMode==APIMode.EditorGUI)
            _api=_editorGuiApi;
    }
    #region Color
    private bool _isgUIColor;
    private void GUI_Color()
    {
        _isgUIColor = GUILayout.Toggle(_isgUIColor,"是否可以变换颜色");
        if (_isgUIColor)
        {
            GUI.color=Color.red;
        }
        _api.Draw();
    }
    #endregion
    #region Scale
    private bool _isgUIScale;
    private void GUI_Scale()
    {
        _isgUIScale = GUILayout.Toggle(_isgUIScale,"是否可以缩放");
        if (_isgUIScale)
        {
            GUIUtility.ScaleAroundPivot(Vector2.one*0.5f, Vector2.zero);
        }
        _api.Draw();
    }
    #endregion
    #region Rotate
    private bool _isgUIRotate;
    private void GUI_Rotate()
    {
        _isgUIRotate = GUILayout.Toggle(_isgUIRotate,"是否可以旋转");
        if (_isgUIRotate)
        {
            GUIUtility.RotateAroundPivot(40f,Vector2.zero);
        }
        _api.Draw();
    }
    

    #endregion
    #region Enabled
    private bool _isgUIEnabled;
    private void GUI_Enabled()
    {
        _isgUIEnabled = GUILayout.Toggle(_isgUIEnabled,"是否可以点击");
        if (GUI.enabled != _isgUIEnabled)
        {
            GUI.enabled = _isgUIEnabled;
        }
        _api.Draw();
    }
    

    #endregion

   
}