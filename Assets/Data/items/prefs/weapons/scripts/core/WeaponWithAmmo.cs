using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponWithAmmo : Weapon
{
    public Bullet bullet;
    protected GameObject tempObj;
    public GameObject shootEffect;

    public override void Shoot()
    {
        tempObj = Instantiate(bullet.gameObject, rifleBarrel.position, Quaternion.Euler(bullet.transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0)) as GameObject;
        Instantiate(shootEffect, rifleBarrel.position, shootEffect.transform.rotation);
    }
}