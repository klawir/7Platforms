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
                protected GameObject tempObj;
                public GameObject shootEffect;

                public override void Shoot()
                {
                    tempObj = Instantiate(bullet.gameObject, rifleBarrel) as GameObject;
                    Instantiate(shootEffect, rifleBarrel.position, shootEffect.transform.rotation);
                }
            }
        }
    }
}