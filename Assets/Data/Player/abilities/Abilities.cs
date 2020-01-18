using Player.Weapon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Abilities : MonoBehaviour
    {
        public Atributes atributes;
        public Model playersModel;
        public WeaponManager weaponSwitcher;
        public Transform root;

        public Shooting shooting;
        public Command movement;
        public Command jump;
        public Command sprint;
        public Command backToNormalSpeed;

        private bool wasJumping;

        private void Start()
        {
            movement = new Movement(root, playersModel);
            jump = new Jump(playersModel.gameObject);
            jump.Lock();
            sprint = new Sprint(atributes);
            sprint.Lock();
            backToNormalSpeed = new BackToNormalSpeed(atributes);
            shooting = new Shooting(weaponSwitcher);
            shooting.Reinit(weaponSwitcher);
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
}