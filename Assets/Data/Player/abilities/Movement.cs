using Player.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement: Command
{
    private Atributes atributes;
    private Model model;
    private float xAxis;
    private float zAxis;

    public Movement(Atributes atributes, Model model)
    {
        this.atributes = atributes;
        this.model = model;
    }
    public override void Execute()
    {
        xAxis = Input.GetAxis("Horizontal") * atributes.speed * Time.deltaTime;
        zAxis = Input.GetAxis("Vertical") * atributes.speed * Time.deltaTime;
        Move.movementVector = new Vector3(xAxis, 0, zAxis);
        atributes.UpdatePos();
        model.UpdateRotation();
    }
}
