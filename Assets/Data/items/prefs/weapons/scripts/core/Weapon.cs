using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    namespace Weapon
    {
        namespace TypeOf
        {
            public abstract class Weapon : MonoBehaviour
            {
                public Transform rifleBarrel;
                public float speedAttack;
                protected Delay delay;

                protected virtual void Start()
                {
                    delay = new Delay(speedAttack);
                }

                public abstract void Shoot();
            }
        }
    }
}
