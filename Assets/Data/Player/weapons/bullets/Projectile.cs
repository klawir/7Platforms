using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Bullet
{
    public override void Momentum(Transform rifleBarrel)
    {
        base.Momentum(rifleBarrel);
    }
    protected override void OnTriggerEnter(Collider other)
    {
        //if(other.CompareTag("enemy"))
        Debug.Log("Projectile");
    }
}
