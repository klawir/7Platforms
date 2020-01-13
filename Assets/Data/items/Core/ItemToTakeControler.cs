using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnTheGround
{
    public class ItemToTakeControler : DetectorController
    {
        public GameObject root;

        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);
        }
        protected override void OnTriggerExit(Collider other)
        {
            base.OnTriggerExit(other);
        }
        protected virtual void Update()
        {
            if (playerInZone)
                Destroy(root);
        }
        protected virtual void OnDestroy()
        {

        }
    }
}