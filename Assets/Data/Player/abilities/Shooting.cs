using Player.Weapon;
using Player.Weapon.TypeOf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting :Ability, Command
{
    private Delay delay;
    public float speed;
    public float shootMomentInPercent;

    private Weapon weapon;
    private AudioSource weaponsSFX;
    private AnimManager animManager;

    public Shooting(WeaponManager weaponSwitcher)
    {
        weaponSwitcher.SwitchToFastShootingWeapon();
        delay = new Delay();
        delay.Init(speed);
        weapon = weaponSwitcher.CurrentChosenWeapon;
        animManager = weaponSwitcher.animManager;
    }
    public void InitChosenWeapon(WeaponManager weaponSwitcher)
    {
        delay.Init(speed);
        speed = weaponSwitcher.CurrentChosenWeapon.speedAttack;
        weapon = weaponSwitcher.CurrentChosenWeapon;
        weaponsSFX = weapon.audio;
        animManager = weaponSwitcher.animManager;
    }
    public override void Execute()
    {
        animManager.Attack();
        if (!delay.IsOver)
            animManager.ResetAttack();
        if (animManager.IsHitMomment)
        {
            weaponsSFX.Play();
            weapon.Shoot();
            delay.Init(speed);
        }
    }
}
