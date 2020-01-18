using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class Navigation : MonoBehaviour
    {
        public PlatformTerrain platform;
        public NavMeshAgent agent;
        public Transform model;
        public Avoidance avoidance;
        public AnimManager animManager;
        public Combat combat;
        public Health health;
        
        private Vector3 pos;

        private void Update()
        {
            if (!health.IsDead)
            {
                if (platform.IsPlayerDetected)
                {
                    if (combat.IsPlayerInRange)
                    {
                        avoidance.Enable();
                        Disable();
                    }
                    else
                    {
                        avoidance.Disable();
                        Enable();
                        Go();
                    }
                }

                else
                {
                    animManager.Idle();
                    avoidance.Enable();
                    Disable();
                }
            }
        }
        public void Enable()
        {
            agent.enabled = true;
        }
        public void Disable()
        {
            agent.enabled = false;
        }
        private void Go()
        {
            InitPlayersPos();
            FixPos();
            animManager.Go();
        }
        private void InitPlayersPos()
        {
            agent.destination = platform.DetectedPlayerPos;
        }
        private void FixPos()
        {
            pos = transform.position;
            pos.y = -1;
            model.position = pos;
        }
    }
}