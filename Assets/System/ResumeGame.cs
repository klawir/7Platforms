using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeGame : Ability, Command
{
    private CursorManager cursorManager;

    public ResumeGame()
    {
        cursorManager = new CursorManager();
    }
    public override void Execute()
    {
        PauseMenuManagment.instance.TurnOffWindow();
        TimeManager.instance.Resume();
        cursorManager.Disable();
    }
}
