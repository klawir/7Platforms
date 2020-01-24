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

        public float modelPositionLerping;
        private Vector3 pos;

        private void Update()
        {
            if (!combat.IsDead)
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
                        if(agent.enabled)
                            Go();
                        else
                        {
                            if(!avoidance.IsObstacleEnable)
                                Enable();
                            avoidance.Disable();
                        }
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

            Moving();
            avoidance.GoToPosition(pos);
        }
        private void Moving()
        {
            model.position = Vector3.Lerp(model.position, agent.transform.position, Time.deltaTime * modelPositionLerping);
        }
        private void InitPlayersPos()
        {
            agent.destination = platform.DetectedPlayer.transform.position;
        }
        private void FixPos()
        {
            pos = transform.position;
            pos.y = 0;
        }
    }
}