using System;
using System.Collections;
using System.Collections.Generic;
using Editor._01.MenuItem.WindowsExample;
using UnityEngine;

public class MyRunTime : MonoBehaviour
{
    private APIMode _apiMode;
    private API _api;
    private GUILayoutAPI _guiLayoutApi=new GUILayoutAPI();
    private GUIAPI _guiApi=new GUIAPI();
    private void OnGUI()
    {
        _apiMode=(APIMode)GUILayout.Toolbar((int) _apiMode, Enum.GetNames(typeof(APIMode)));
        SwitchAPI();
        _api.Draw();
    }
    
    private void SwitchAPI()
    {
        if(_apiMode==APIMode.GUILayout)
            _api=_guiLayoutApi;
        else
            _api=_guiApi;
    }
    
    
    
    
    
    
    
    
    public enum APIMode
    {
        GUILayout,
        GUI
    }
}
