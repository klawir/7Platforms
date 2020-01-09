using Player.Weapon.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    public GameObject playerTransf;
    public Model playersModel;
    public WeaponSwitcher weaponSwitcher;

    public Ability shooting;
    public Ability movement;
    public Ability jump;

    private void Start()
    {
        shooting = new Shooting(weaponSwitcher);
        movement = new Movement(playerTransf, playersModel);
        jump = new Jump(playersModel.gameObject);
        jump.Lock();
    }
}
