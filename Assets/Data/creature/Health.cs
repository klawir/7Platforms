using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float current;
    public Player.GUI gui;

    private void Awake()
    {
        gui.UpdateHealth(this);
    }

    public bool IsDead
    {
        get { return current <= 0; }
    }
}