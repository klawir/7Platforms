using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : Ability, Command
{
    protected Rigidbody rigidbody;
    public float velocity;

    protected Model model;
    protected bool canDoubleAvailable;

    public Jump(GameObject modelObj)
    {
        velocity = 7;
        rigidbody = modelObj.GetComponent<Rigidbody>();
        model = modelObj.GetComponent<Model>();
        canDoubleAvailable = true;
    }
    public override void Execute()
    {
        if (model.IsGrounded)
        {
            if (!canDoubleAvailable)
                canDoubleAvailable = true;
            Do();
        }
        else
        {
            if (canDoubleAvailable && !blockade)
            {
                Do();
                if (canDoubleAvailable)
                    canDoubleAvailable = false;
            }
        }
    }
    protected void Do()
    {
        rigidbody.velocity = Vector3.up * velocity;
    }
}