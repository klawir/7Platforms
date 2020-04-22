using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLose : GameOver
{
    private bool playerOutOfTheMap;
    
    private void Start()
    {
        delay = new Delay();
    }
    private void Update()
    {
        if(playerOutOfTheMap)
        {
            if (delay.IsOver)
            {
                gameState.DeleteLastGameState();
                cursorManager.Enable();
                managerScene.LoadMainMenu();
            }
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        delay.Init(duration);
        Destroy(col.gameObject);
        text.enabled = true;
        playerOutOfTheMap = true;
    }
}
