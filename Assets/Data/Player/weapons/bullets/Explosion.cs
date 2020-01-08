using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : BulletDecorator
{
    public float dmg;

    public Explosion(Bullet bullet) : base(bullet)
    {
    }

    protected override void OnTriggerEnter(Collider other)
    {
        Debug.Log("Explosion");
    }
}
