using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    namespace Weapon
    {
        namespace TypeOf
        {
            public abstract class WeaponWithAmmo : Weapon
            {
                public Bullet bullet;
                public Transform rifleBarrel;
                protected GameObject tempObj;

                public override void Shoot()
                {
                    tempObj = Instantiate(bullet.gameObject, rifleBarrel.position, bullet.transform.rotation) as GameObject;
                    
                }
            }
        }
    }
}