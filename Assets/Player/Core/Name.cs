using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Name : MonoBehaviour
{
    public string _name;
    public Text gui;

    public void Awake()
    {
        LoadEnteredData();
    }

    public void Update(string value)
    {
        _name = value;
        gui.text = value;
    }
    public void Update(DataToSave dataToSave)
    {
        _name = dataToSave.name;
        gui.text = _name;
    }
    public void LoadEnteredData()
    {
        _name = RememberUserData.Name;
        Update(_name);
    }
}
