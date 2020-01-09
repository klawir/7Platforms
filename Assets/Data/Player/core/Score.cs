using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private float value;
    public Text text;

    private void Start()
    {
        value = 0;
        UpdateGUI();
    }
    public void Add(Reward value)
    {
        this.value += value.score;
        UpdateGUI();
    }
    public void Remove(float value)
    {
        this.value -= value;
        UpdateGUI();
    }
    private void UpdateGUI()//duplicate with health
    {
        text.text = "score: " + value.ToString();
    }
}