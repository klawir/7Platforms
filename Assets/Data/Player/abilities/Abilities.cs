
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    public Atributes atributes;
    public Model playersModel;
    public WeaponManager weaponSwitcher;
    public Transform root;

    public Shooting shooting;
    public Ability movement;
    public Ability jump;
    public Ability sprint;
    public Ability backToNormalSpeed;

    private bool wasJumping;

    private void Start()
    {
        movement = new Movement(root);
        jump = new Jump(playersModel.gameObject);
        jump.Lock();
        sprint = new Sprint(root);
        sprint.Lock();
        backToNormalSpeed = new BackToNormalSpeed(root);
        shooting = new Shooting(weaponSwitcher);
        shooting.InitChosenWeapon(weaponSwitcher);
    }
    private void Update()
    {
        if (playersModel.IsInTheAir)
            wasJumping = true;
        if (playersModel.IsGrounded && wasJumping)
        {
            backToNormalSpeed.Execute();
            wasJumping = false;
        }
    }
}