using Player.Model;
using Player.Weapon.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    public Atributes atributes;
    public Model playersModel;
    public WeaponSwitcher weaponSwitcher;

    public Command shooting;
    public Command movement;
    public Command jump;
    public Command sprint;
    public Command backToNormalSpeed;

    private void Start()
    {
        shooting = new Shooting(weaponSwitcher);
        movement = new Movement(atributes, playersModel);
        jump = new Jump(playersModel.gameObject);
        jump.Lock();
        sprint = new Sprint(atributes);
        sprint.Lock();
        backToNormalSpeed = new BackToNormalSpeed(atributes);
    }
}
