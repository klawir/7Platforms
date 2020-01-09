﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    namespace Weapon
    {
        namespace Model
        {
            public class WeaponSwitcher : MonoBehaviour
            {
                enum weaponsList { fastShootingWeapon, raycastWeapon, bazooke }

                public List<TypeOf.Weapon> weapons;
                private TypeOf.Weapon weapon;

                private void Start()
                {
                    //foreach:
                    weapons[(int)weaponsList.fastShootingWeapon].GetComponent<TypeOf.Weapon>().rifleBarrel = transform;
                    weapons[(int)weaponsList.bazooke].GetComponent<TypeOf.Weapon>().rifleBarrel = transform;
                    weapons[(int)weaponsList.raycastWeapon].GetComponent<TypeOf.Weapon>().rifleBarrel = transform;
                }

                public void SwitchToFastShootingWeapon()
                {
                    weapon = weapons[(int)weaponsList.fastShootingWeapon];
                }
                public void SwitchToRaycastWeapon()
                {
                    weapon = weapons[(int)weaponsList.raycastWeapon];
                }
                public void SwitchToBazooke()
                {
                    weapon = weapons[(int)weaponsList.bazooke];
                }
                public TypeOf.Weapon CurrentChosenWeapon
                {
                    get { return weapon; }
                }
            }
        }
    }
}