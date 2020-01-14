using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprint : Command
{
    private Atributes atributes;
    private int accelerate;

    public Sprint(Atributes atributes)
    {
        this.atributes = atributes;
        accelerate = Calculate;
    }
    public override void Execute()
    {
        if(!blockade)
            Accelerate();
    }
    private void Accelerate()
    {
        atributes.speed = accelerate;
    }
    private int Calculate
    {
        get { return atributes.speed * 2; }
    }
}
