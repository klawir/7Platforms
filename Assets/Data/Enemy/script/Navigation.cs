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

        private Vector3 pos;

        private void Update()
        {
            if (platform.IsPlayerDetected)
                Go();
        }

        private void Go()
        {
            InitPlayersPos();
            FixPos();
        }
        private void InitPlayersPos()
        {
            agent.destination = platform.DetectedPlayerPos;
        }
        private void FixPos()
        {
            pos = transform.position;
            pos.y = 0;
            model.position = pos;
        }
    }
}