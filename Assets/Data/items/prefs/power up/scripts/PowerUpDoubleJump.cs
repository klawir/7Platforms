using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnTheGround
{
    public class PowerUpDoubleJump : PowerUpControler
    {
        protected override void Start()
        {
            base.Start();
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
            player.UnlockDoubleJump();
        }
    }
}
