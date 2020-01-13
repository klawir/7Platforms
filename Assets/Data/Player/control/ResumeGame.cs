using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Menu;

public class ResumeGame : Command
{
    public override void Execute()
    {
        PauseMenuManagment.instance.TurnOffWindow();
    }
}
