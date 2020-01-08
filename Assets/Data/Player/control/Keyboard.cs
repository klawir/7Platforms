using Player.Weapon.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    public GameObject playerTransf;
    public Model playersModel;
    public WeaponSwitcher weaponSwitcher;
    
    private Command movement;
    private Command jump;
    private Jump doubleJump;

    private void Start()
    {
        movement = new Movement(playerTransf, playersModel);
        jump = new Jump(playersModel.gameObject);
        doubleJump = new Jump(playersModel.gameObject);
    }
    void Update()
    {
        if (playersModel.IsGrounded)
        {
            if (Input.GetKey(KeyCode.W)
                || Input.GetKey(KeyCode.A)
                || Input.GetKey(KeyCode.S)
                || Input.GetKey(KeyCode.D))
                movement.Execute();

            doubleJump.Reset();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
            weaponSwitcher.SwitchToFastShootingWeapon();
        if (Input.GetKeyDown(KeyCode.Alpha2))
            weaponSwitcher.SwitchToRaycastWeapon();
        if (Input.GetKeyDown(KeyCode.Alpha3))
            weaponSwitcher.SwitchToBazooke();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump.Execute();
            doubleJump.Execute();
        }
    }
}