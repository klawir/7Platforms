using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class Combat : BaseCombat
    {
        public float range;
        public int dmg;
        public Navigation navigation;
        public PlatformTerrain platformTerrain;
        private Delay delay;
        public float speed;
        public Reward reward;
        

        private void Start()
        {
            delay = new Delay(speed);
            delay.Init(speed);
        }
        protected override void Update()
        {
            base.Update();

            if(platformTerrain.IsPlayerDetected)
            {
                if (IsPlayerInRange)
                {
                    if(delay.IsOver)
                    {
                        delay.Init(speed);
                        Hit();
                    }
                }
            }
        }

        private bool IsPlayerInRange
        {
            get { return Vector3.Distance(transform.position, platformTerrain.DetectedPlayerPos) < range; }
        }
        public override void TakeDmg(int dmg)
        {
            base.TakeDmg(dmg);
        }
        public void Hit()
        {
            platformTerrain.DetectedPlayer.GetComponent<BaseCombat>().TakeDmg(dmg);
        }
        protected override void Die()
        {
            base.Die();
            Destroy(transform.parent.gameObject);
        }
        private void OnDestroy()
        {
            platformTerrain.DetectedPlayer.GetComponent<Player.Combat>().score.Add(reward);
        }
    }
}