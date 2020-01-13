using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnTheGround
{
    public abstract class PowerUpControler : ItemToTakeControler
    {
        public Model player;

        protected virtual void Start()
        {
            player = GameObject.FindObjectOfType<Model>();

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
        }
    }
}