using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToNormalSpeed :Ability, Command
{
    private Atributes atributes;
    private int speed;

    public BackToNormalSpeed(Atributes atributes)
    {
        this.atributes = atributes;
        speed = atributes.speed;
    }
    public override void Execute()
    {
        Speed();
    }
    private void Speed()
    {
        atributes.speed = speed;
    }
}
