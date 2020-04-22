using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnTheGround
{
    public class ItemToTake : ItemToTakeControler
    {
        public Reward reward;
        private KeyCollection playerKeys;
        private Score playerScore;

        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);
            if (other.gameObject.CompareTag(playerTag))
            {
                playerKeys = other.transform.parent.GetComponentInChildren<KeyCollection>();
                playerScore= other.transform.parent.GetComponentInChildren<Score>();
                Destroy(root);
            }
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
            playerScore.Add(reward);
            if (root.name == "key(Clone)")
                playerKeys.TakeKey();
        }
    }
}