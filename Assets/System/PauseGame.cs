using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : Ability, Command
{
    private CursorManager cursorManager;

    public PauseGame()
    {
        cursorManager = new CursorManager();
    }

    public override void Execute()
    {
        if (!PauseMenuManagment.instance.pause.activeInHierarchy)
        {
            PauseMenuManagment.instance.TurnOnWindow();
            TimeManager.instance.Stop();
            cursorManager.Enable();
        }
    }
}
