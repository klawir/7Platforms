using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Congratulations : GameOver
{

    private void OnEnable()
    {
        delay = new Delay();
        delay.Init(duration);
        text.enabled = true;
        gameState.Save(true);
    }
    private void Update()
    {
        if (delay.IsOver)
        {
            managerScene.LoadScoreBoard();
            cursorManager.Enable();
        }
    }
}
