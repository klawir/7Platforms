using Player.Weapon.Model;
using Player.Weapon.TypeOf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public WeaponSwitcher weaponSwitcher;

    private void Start()
    {
        weaponSwitcher.SwitchToFastShootingWeapon();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            weaponSwitcher.CurrentChosenWeapon.Shoot();
        }
    }
}
