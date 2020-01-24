using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class Combat : BaseCombat
    {
        public float range;
        public int dmg;
        public float hitMomment;

        public Navigation navigation;
        public PlatformTerrain platformTerrain;
        public Reward reward;
        public AnimManager animManager;
        public AudioSource attack;
        public Collider collider;
        public Transform model;

        private BaseCombat detectedPlayer;
        private bool wasHit;

        protected override void Update()
        {
            base.Update();

            if (!IsDead)
            {
                if (platformTerrain.IsPlayerDetected)
                {
                    if(detectedPlayer==null)
                        detectedPlayer = platformTerrain.DetectedPlayer;
                    if (IsPlayerInRange)
                    {
                        model.LookAt(detectedPlayer.transform);
                        animManager.Attack();
                        if (animManager.IsHitMomment && !wasHit)
                        {
                            attack.Play();
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
        public bool IsDead
        {
            get { return health.IsDead; }
        }
        public bool IsPlayerInRange
        {
            get { return Vector3.Distance(transform.position, detectedPlayer.transform.position) < range; }
        }
        public override void TakeDmg(int dmg)
        {
            base.TakeDmg(dmg);
        }
        public void Hit()
        {
            detectedPlayer.TakeDmg(dmg);
        }
        protected override void Die()
        {
            base.Die();
            Destroy(collider);
            animManager.Die();
        }
        private void OnDestroy()
        {
            GameObject.FindObjectOfType<Player.Combat>().score.Add(reward);
        }
    }
}