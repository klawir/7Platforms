using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float current;
    public Text text;

    public bool IsDead
    {
        get { return current <= 0; }
    }
    public void UpdateGUI()
    {
        text.text = "health: " + current.ToString();
    }
}