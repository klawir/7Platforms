using Menu;
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

    private Command pauseMenu;

    private void Start()
    {
        pauseMenu = new PauseGame();
    }
    void Update()
    {
        if (playersModel.IsGrounded)
        {
            if (Input.GetKey(KeyCode.W)
                || Input.GetKey(KeyCode.A)
                || Input.GetKey(KeyCode.S)
                || Input.GetKey(KeyCode.D))
            {
                abilities.movement.Execute();
                if (Input.GetKeyDown(KeyCode.LeftShift))
                    abilities.sprint.Execute();
                if (Input.GetKeyUp(KeyCode.LeftShift))
                    abilities.backToNormalSpeed.Execute();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponSwitcher.SwitchToFastShootingWeapon();
            abilities.shooting.Reinit(weaponSwitcher);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weaponSwitcher.SwitchToRaycastWeapon();
            abilities.shooting.Reinit(weaponSwitcher);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            weaponSwitcher.SwitchToBazooke();
            abilities.shooting.Reinit(weaponSwitcher);
        }
        if (Input.GetKeyDown(KeyCode.Space))
            abilities.jump.Execute();

        if (Input.GetMouseButton(0))
            abilities.shooting.Execute();

        if (Input.GetKeyDown(KeyCode.Escape)) 
            if (!PauseMenuManagment.instance.pause.activeInHierarchy)
                pauseMenu.Execute();
    }
}