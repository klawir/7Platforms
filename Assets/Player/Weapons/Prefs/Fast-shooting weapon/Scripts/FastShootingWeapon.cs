using UnityEngine;

public class FastShootingWeapon : WeaponWithAmmo
{
    protected override void Start()
    {
        base.Start();
    }
    public override void Shoot()
    {
        base.Shoot();
        tempObj.GetComponent<Projectile>().Momentum(rifleBarrel);
    }
}