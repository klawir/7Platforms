using Player.Weapon.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    public GameObject playerTransf;
    public Model playersModel;
    public WeaponSwitcher weaponSwitcher;
    public Abilities abilities;

    void Update()
    {
        if (playersModel.IsGrounded)
        {
            if (Input.GetKey(KeyCode.W)
                || Input.GetKey(KeyCode.A)
                || Input.GetKey(KeyCode.S)
                || Input.GetKey(KeyCode.D))
                abilities.movement.Execute();

            //abilities.doubleJump.Reset();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
            weaponSwitcher.SwitchToFastShootingWeapon();
        if (Input.GetKeyDown(KeyCode.Alpha2))
            weaponSwitcher.SwitchToRaycastWeapon();
        if (Input.GetKeyDown(KeyCode.Alpha3))
            weaponSwitcher.SwitchToBazooke();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            abilities.jump.Execute();
            //abilities.doubleJump.Execute();
        }
        if (Input.GetMouseButton(0))
            abilities.shooting.Execute();
    }
}