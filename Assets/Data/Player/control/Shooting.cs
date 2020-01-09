using Player.Weapon.Model;
using Player.Weapon.TypeOf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public WeaponSwitcher weaponSwitcher;
    private Delay delay;
    public float speed;

    private void Start()
    {
        weaponSwitcher.SwitchToFastShootingWeapon();
        delay = new Delay(speed);
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (delay.IsOver)
            {
                delay.Init(speed);
                weaponSwitcher.CurrentChosenWeapon.Shoot();
            }
        }
    }
}
