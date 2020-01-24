using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace AI
{
    public class Model : MonoBehaviour
    {
        public NavMeshAgent nav;

        private void Update()
        {
            if (nav.enabled) 
                UpdateRotate();
        }

        private void UpdateRotate()
        {
            transform.rotation = nav.transform.rotation;
        }
    }
}