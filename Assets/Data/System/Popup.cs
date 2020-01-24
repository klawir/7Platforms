using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    public InputField userName;
    public ManagerScene managerScene;
    public CursorManager cursorManager;

    private void OnDisable()
    {
        DeleteEnteredData();
    }
    public void TurnOffWindow()
    {
        gameObject.SetActive(false);
    }
    public void TurnOnWindow()
    {
        gameObject.SetActive(true);
    }
    public void DeleteEnteredData()
    {
        userName.text="";
    }
    private void RememberUserName()
    {
        RememberUserData.SetName(userName.text);
    }
    public void Accept()
    {
        if(IsUserNameNotEmpty)
        {
            RememberUserName();
            managerScene.LoadGameScene();
            cursorManager.Disable();
        }
    }
    private bool IsUserNameNotEmpty
    {
        get { return !string.IsNullOrEmpty(userName.text); }
    }
}
