using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprint : Ability, Command
{
    private Atributes atributes;
    private int accelerate;
    private Model model;

    public Sprint(Transform rootPlayer)
    {
        atributes = rootPlayer.GetComponentInChildren<Atributes>();
        accelerate = Calculate;
        model = rootPlayer.GetComponentInChildren<Model>();
    }
    public override void Execute()
    {
        if(model.IsGrounded)
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
