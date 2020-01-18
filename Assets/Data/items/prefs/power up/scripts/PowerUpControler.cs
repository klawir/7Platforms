using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnTheGround
{
    public class PowerUpControler : ItemToTakeControler
    {
        private Player.Model player;

        public bool sprint;

        protected virtual void Start()
        {
            player = GameObject.FindObjectOfType<Player.Model>();

        }
        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);
        }
        protected override void OnTriggerExit(Collider other)
        {
            base.OnTriggerExit(other);
        }
        protected override void Update()
        {
            base.Update();
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();

            if (sprint)
                player.UnlockSprint();
            else
                player.UnlockDoubleJump();
        }
    }
}