using Player.Weapon;
using Player.Weapon.TypeOf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : Command
{
    private WeaponManager weaponSwitcher;
    private Delay delay;
    public float speed;

    public Shooting(WeaponManager weaponSwitcher)
    {
        this.weaponSwitcher = weaponSwitcher;
        weaponSwitcher.SwitchToFastShootingWeapon();
        delay = new Delay(speed);
    }
    public void Reinit(WeaponManager weaponSwitcher)
    {
        delay.Init(speed);
        this.weaponSwitcher = weaponSwitcher;
        speed = weaponSwitcher.CurrentChosenWeapon.speedAttack;
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
