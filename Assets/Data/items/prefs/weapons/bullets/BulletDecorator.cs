using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletDecorator : Bullet
{
    protected Bullet decoratedWeapon;

    public override void Momentum(Transform rifleBarrel)
    {
        base.Momentum(rifleBarrel);
    }
}
