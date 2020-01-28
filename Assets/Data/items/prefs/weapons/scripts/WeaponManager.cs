using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    enum weaponsList { fastShootingWeapon, raycastWeapon, bazooke }

    public List<float> weaponsSpeedAttack;
    public List<Weapon> typeOfWeapons;
    public Weapon weapon;
    private Weapon spawnedWeapon;
    public Transform hands;
    public AnimManager animManager;
    public Abilities abilities;

    public Image fastShooting;
    public Image rayGun;
    public Image bazooke;

    private void Start()
    {
        SwitchToFastShootingWeapon();
    }
    public void GUISwitchToFastShooting()
    {
        fastShooting.color = Color.green;
        DeselectRayGun();
        DeselectBazooke();
    }
    public void GUISwitchToRayGun()
    {
        rayGun.color = Color.green;
        DeselectFastShooting();
        DeselectBazooke();
    }
    public void GUISwitchToBazooke()
    {
        bazooke.color = Color.green;
        DeselectFastShooting();
        DeselectRayGun();
    }
    private void DeselectFastShooting()
    {
        fastShooting.color = Color.white;
    }
    private void DeselectRayGun()
    {
        rayGun.color = Color.white;
    }
    private void DeselectBazooke()
    {
        bazooke.color = Color.white;
    }
    public void SwitchToFastShootingWeapon()
    {
        DeleteCurrentChosenIfExist();
        weapon = typeOfWeapons[(int)weaponsList.fastShootingWeapon];
        spawnedWeapon = Instantiate(typeOfWeapons[(int)weaponsList.fastShootingWeapon], hands) as Weapon;
        weapon = spawnedWeapon;
        weapon.speedAttack = weaponsSpeedAttack[(int)weaponsList.fastShootingWeapon];
        animManager.SwitchToFastShootingWeapon();
        GUISwitchToFastShooting();
        abilities.shooting.InitChosenWeapon(this);
    }
    public void SwitchToRaycastWeapon()
    {
        DeleteCurrentChosenIfExist();
        weapon = typeOfWeapons[(int)weaponsList.raycastWeapon];
        spawnedWeapon = Instantiate(typeOfWeapons[(int)weaponsList.raycastWeapon], hands) as Weapon;
        weapon = spawnedWeapon;
        weapon.speedAttack = weaponsSpeedAttack[(int)weaponsList.raycastWeapon];
        animManager.SwitchToRaycastWeapon();
        GUISwitchToRayGun();
        abilities.shooting.InitChosenWeapon(this);
    }
    public void SwitchToBazooke()
    {
        DeleteCurrentChosenIfExist();
        weapon = typeOfWeapons[(int)weaponsList.bazooke];
        spawnedWeapon = Instantiate(typeOfWeapons[(int)weaponsList.bazooke], hands) as Weapon;
        weapon = spawnedWeapon;
        weapon.speedAttack = weaponsSpeedAttack[(int)weaponsList.bazooke];
        animManager.SwitchToBazooke();
        GUISwitchToBazooke();
        abilities.shooting.InitChosenWeapon(this);
    }

    private bool IsPlayerHasAnyWeapon
    {
        get { return hands.childCount > 0; }
    }
    public void DeleteCurrentChosenIfExist()
    {
        if (IsPlayerHasAnyWeapon)
            foreach (Transform weapon in hands)
                Destroy(weapon.gameObject);
    }
    public Weapon CurrentChosenWeapon
    {
        get { return weapon; }
    }
}