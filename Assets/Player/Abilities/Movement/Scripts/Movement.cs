using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : Ability, Command
{
    private Atributes atributes;
    private Model model;
    private float xAxis;
    private float zAxis;
    private Transform root;
    private AnimManager animManager;

    public Movement(Transform root)
    {
        this.atributes = root.GetComponentInChildren<Atributes>();
        this.model = root.GetComponentInChildren<Model>();
        this.root = root;
        animManager = root.GetComponentInChildren<AnimManager>();
    }
    public override void Execute()
    {
        if (model.IsGrounded)
        {
            xAxis = Input.GetAxis("Horizontal") * atributes.speed * Time.deltaTime;
            zAxis = Input.GetAxis("Vertical") * atributes.speed * Time.deltaTime;
            Move.movementVector = new Vector3(xAxis, 0, zAxis);
            root.Translate(Move.movementVector);
            model.UpdateRotation();
            animManager.Go();
        }
    }
}