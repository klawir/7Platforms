using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    namespace Weapon
    {
        namespace TypeOf
        {
            public class Bazooke : WeaponWithAmmo
            {

                public override void Shoot()
                {
                    base.Shoot();
                    tempObj.GetComponent<Rocket>().Momentum(rifleBarrel);
                }
            }
        }
    }
}