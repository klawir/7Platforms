using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float current;
    public Text gui;

    private void Awake()
    {
        UpdateGUI();
    }
    public void UpdateGUI()
    {
        gui.text = current.ToString();
    }
    public void Update(DataToSave value)
    {
        current = value.health;
        UpdateGUI();
    }
    public void Remove(int value)
    {
        current -= value;
        if(gui!=null)
            UpdateGUI();
    }
    public bool IsDead
    {
        get { return current <= 0; }
    }
}