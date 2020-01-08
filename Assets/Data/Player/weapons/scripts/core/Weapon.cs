using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    namespace Weapon
    {
        namespace TypeOf
        {
            public abstract class Weapon : MonoBehaviour, IWeapon
            {
                public abstract void Shoot();
            }
        }
    }
}
