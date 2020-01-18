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
        public Reward reward;
        public float hitMomment;
        private bool wasHit;
        public AnimManager animManager;

        protected override void Update()
        {
            base.Update();

            if (!health.IsDead)
            {
                if (platformTerrain.IsPlayerDetected)
                {
                    if (IsPlayerInRange)
                    {
                        animManager.Attack();
                        if (animManager.IsHitMomment(hitMomment) && !wasHit)
                        {
                            Hit();
                            wasHit = true;
                        }
                        if (animManager.IsBeginningOfAttack)
                            wasHit = false;
                    }
                }
            }
            if (animManager.IsEndOfDeadAnim)
                Destroy(transform.parent.gameObject);
        }

        public bool IsPlayerInRange
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
            animManager.Die();
        }
        private void OnDestroy()
        {
            platformTerrain.DetectedPlayer.GetComponent<Player.Combat>().score.Add(reward);
        }
    }
}