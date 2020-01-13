using System.Collections;
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

                public List<float> weaponsSpeedAttack;
                public List<TypeOf.Weapon> weapons;
                private TypeOf.Weapon weapon;

                private void Start()
                {
                    Prepare();
                }

                private void Prepare()
                {
                    foreach (TypeOf.Weapon weapon in weapons)
                        weapon.rifleBarrel = transform;
                }
                public void SwitchToFastShootingWeapon()
                {
                    weapon = weapons[(int)weaponsList.fastShootingWeapon];
                    weapon.speedAttack = weaponsSpeedAttack[(int)weaponsList.fastShootingWeapon];
                }
                public void SwitchToRaycastWeapon()
                {
                    weapon = weapons[(int)weaponsList.raycastWeapon];
                    weapon.speedAttack=weaponsSpeedAttack[(int)weaponsList.raycastWeapon];
                }
                public void SwitchToBazooke()
                {
                    weapon = weapons[(int)weaponsList.bazooke];
                    weapon.speedAttack = weaponsSpeedAttack[(int)weaponsList.bazooke];
                }
                public TypeOf.Weapon CurrentChosenWeapon
                {
                    get { return weapon; }
                }
            }
        }
    }
}