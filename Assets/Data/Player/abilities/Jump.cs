using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : Command
{
    private Rigidbody rigidbody;
    private Model model;
    private float velocity;
    private bool canDoubleAvailable;

    public Jump(GameObject modelObj)
    {
        velocity = 10;
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
            rigidbody.velocity = Vector3.up * velocity;
        }
        else
        {
            if (canDoubleAvailable && !blockade)
            {
                rigidbody.velocity = Vector3.up * velocity;
                if (canDoubleAvailable)
                    canDoubleAvailable = false;
            }
        }
    }
}