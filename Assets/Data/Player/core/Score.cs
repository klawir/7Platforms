using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private float amount;
    public Text text;

    private void Awake()
    {
        amount = 0;
        UpdateGUI();
        
    }
    public void Add(Reward value)
    {
        this.amount += value.score;
        UpdateGUI();
    }
    public void Remove(float value)
    {
        this.amount -= value;
        UpdateGUI();
    }
    public void UpdateGUI()//duplicate with health
    {
        text.text = "score: " + amount.ToString();
    }
    public float Value
    {
        get { return amount; }
        set { amount = value; }
    }
}