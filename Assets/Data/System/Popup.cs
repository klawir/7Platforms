using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    public InputField userName;

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
        userName.text = " ";
    }
    public void RememberUserName()
    {
        RememberUserData.SetName(userName.text);
    }
}
