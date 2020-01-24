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
        public GUI gui;

        public Shooting shooting;
        public Ability movement;
        public Ability jump;
        public Ability sprint;
        public Ability backToNormalSpeed;

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

        public void UnlockDoubleJump()
        {
            jump.Unlock();
            gui.DoubleJumpUnlock();
            UISpawnManager.instance.SpawnDoubleJumpInfo();
        }
        public void UnlockSprint()
        {
            sprint.Unlock();
            gui.SprintUnlock();
            UISpawnManager.instance.SpawnSprintInfo();
        }
    }
}