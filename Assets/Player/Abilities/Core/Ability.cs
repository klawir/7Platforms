using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    protected bool blockade;

    public void Unlock()
    {
        blockade = false;
    }
    public void Lock()
    {
        blockade = true;
    }

    public bool Islocked
    {
        get { return blockade; }
    }
    public abstract void Execute();
}
