using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazooke : WeaponWithAmmo
{
    public override void Shoot()
    {
        base.Shoot();
        tempObj.GetComponent<Rocket>().Momentum(rifleBarrel);
    }
}