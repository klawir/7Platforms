using Menu;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : Command
{
    public override void Execute()
    {
        PauseMenuManagment.instance.TurnOnWindow();
    }
}
