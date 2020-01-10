using Player.Weapon.Model;
using Player.Weapon.TypeOf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : Command
{
    private WeaponSwitcher weaponSwitcher;
    private Delay delay;
    public float speed;

    public Shooting(WeaponSwitcher weaponSwitcher)
    {
        this.weaponSwitcher = weaponSwitcher;
        weaponSwitcher.SwitchToFastShootingWeapon();
        delay = new Delay(speed);
    }

    public override void Execute()
    {
        if (delay.IsOver)
        {
            delay.Init(speed);
            weaponSwitcher.CurrentChosenWeapon.Shoot();
        }
    }
}
