using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    namespace Weapon
    {
        namespace TypeOf
        {
            public class RaycastWeapon : Weapon
            {
                private RaycastHit hit;
                private Vector3 fwd;
                public override void Shoot()
                {
                    fwd = rifleBarrel.TransformDirection(Vector3.forward);
                    //Debug.DrawRay(rifleBarrel.position, fwd * 50, Color.green);
                    if (Physics.Raycast(rifleBarrel.position, fwd, out hit, 50))
                    {
                        if (hit.collider.gameObject.layer == 9)
                        {
                            Destroy(hit.collider.gameObject);
                        }
                    }
                }
            }
        }
    }
}