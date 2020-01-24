using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    namespace Weapon
    {
        public class WeaponManager : MonoBehaviour
        {
            enum weaponsList { fastShootingWeapon, raycastWeapon, bazooke }

            public List<float> weaponsSpeedAttack;
            public List<TypeOf.Weapon> typeOfWeapons;
            public TypeOf.Weapon weapon;
            private TypeOf.Weapon spawnedWeapon;
            public Transform hands;
            public AnimManager animManager;
            public GUI gui;

            public void SwitchToFastShootingWeapon()
            {
                weapon = typeOfWeapons[(int)weaponsList.fastShootingWeapon];
                spawnedWeapon = Instantiate(typeOfWeapons[(int)weaponsList.fastShootingWeapon], hands) as TypeOf.Weapon;
                weapon = spawnedWeapon;
                weapon.speedAttack = weaponsSpeedAttack[(int)weaponsList.fastShootingWeapon];
                animManager.SwitchToFastShootingWeapon();
                gui.SelectFastShooting();
            }
            public void SwitchToRaycastWeapon()
            { 
                weapon = typeOfWeapons[(int)weaponsList.raycastWeapon];
                spawnedWeapon = Instantiate(typeOfWeapons[(int)weaponsList.raycastWeapon], hands) as TypeOf.Weapon;
                weapon = spawnedWeapon;
                weapon.speedAttack = weaponsSpeedAttack[(int)weaponsList.raycastWeapon];
                animManager.SwitchToRaycastWeapon();
                gui.SelectRayGun();
            }
            public void SwitchToBazooke()
            {
                weapon = typeOfWeapons[(int)weaponsList.bazooke];
                spawnedWeapon = Instantiate(typeOfWeapons[(int)weaponsList.bazooke], hands) as TypeOf.Weapon;
                weapon = spawnedWeapon;
                weapon.speedAttack = weaponsSpeedAttack[(int)weaponsList.bazooke];
                animManager.SwitchToBazooke();
                gui.SelectBazooke();
            }

            private bool IsPlayerHasAnyWeapon
            {
                get { return hands.childCount > 0; }
            }
            public void DeleteCurrentChosenIfExist()
            {
                if(IsPlayerHasAnyWeapon)
                    foreach (Transform weapon in hands)
                        Destroy(weapon.gameObject);
            }
            public TypeOf.Weapon CurrentChosenWeapon
            {
                get { return weapon; }
            }
        }
    }
}