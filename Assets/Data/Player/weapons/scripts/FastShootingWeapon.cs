using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    namespace Weapon
    {
        namespace TypeOf
        {
            public class FastShootingWeapon : WeaponWithAmmo
            {
                public override void Shoot()
                {
                    base.Shoot();
                    tempObj.GetComponent<Projectile>().Momentum(rifleBarrel);
                }
            }
        }
    }
}