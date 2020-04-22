using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penalty : MonoBehaviour
{
    public int value;
    public Score score;
    private Delay delay;
    public int frequency;

    private void Start()
    {
        delay = new Delay();
        RestartGame();
    }
    private void RestartGame()
    {
        delay.Init(frequency);
    }
    void Update()
    {
        if (delay.IsOver)
        {
            delay.Init(frequency);
            score.Remove(value);
        }
    }
}
