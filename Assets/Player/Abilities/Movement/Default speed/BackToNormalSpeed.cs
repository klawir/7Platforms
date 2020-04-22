using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToNormalSpeed :Ability, Command
{
    private Atributes atributes;
    private int speed;
    private Model model;

    public BackToNormalSpeed(Transform root)
    {
        atributes = root.GetComponentInChildren<Atributes>();
        speed = atributes.speed;
        model = root.GetComponentInChildren<Model>();
    }
    public override void Execute()
    {
        if(model.IsGrounded)
            Restore();
    }
    private void Restore()
    {
        atributes.speed = speed;
    }
}
