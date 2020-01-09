using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour, Command
{
    protected bool blockade;

    public abstract void Execute();
    public void Unlock()
    {
        blockade = false;
    }
    public void Lock()
    {
        blockade = true;
    }
}
