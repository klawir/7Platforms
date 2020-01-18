using Player.Weapon.TypeOf;
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
            public Transform hands;

            public void SwitchToFastShootingWeapon()
            {
                weapon = typeOfWeapons[(int)weaponsList.fastShootingWeapon];
                TypeOf.Weapon _weapon = Instantiate(typeOfWeapons[(int)weaponsList.fastShootingWeapon], hands) as TypeOf.Weapon;
                weapon = _weapon;

                Debug.Log(weapon.gameObject.name+" "+ weapon.rifleBarrel+" "+ weapon.transform.parent.name);
                weapon.speedAttack = weaponsSpeedAttack[(int)weaponsList.fastShootingWeapon];
            }
            public void SwitchToRaycastWeapon()
            { 
                weapon = typeOfWeapons[(int)weaponsList.raycastWeapon];
                TypeOf.Weapon _weapon = Instantiate(typeOfWeapons[(int)weaponsList.raycastWeapon], hands) as TypeOf.Weapon;
                weapon = _weapon;
                Debug.Log(_weapon.gameObject.name + " " + _weapon.rifleBarrel + " " + _weapon.transform.parent.name);
                weapon.speedAttack = weaponsSpeedAttack[(int)weaponsList.raycastWeapon];
            }
            public void SwitchToBazooke()
            {
                weapon = typeOfWeapons[(int)weaponsList.bazooke];
                TypeOf.Weapon _weapon = Instantiate(typeOfWeapons[(int)weaponsList.bazooke], hands) as TypeOf.Weapon;
                weapon = _weapon;
                Debug.Log(_weapon.gameObject.name + " " + _weapon.rifleBarrel + " " + _weapon.transform.parent.name);
                weapon.speedAttack = weaponsSpeedAttack[(int)weaponsList.bazooke];
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