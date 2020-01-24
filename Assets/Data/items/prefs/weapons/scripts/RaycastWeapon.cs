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
                public LineRenderer line;

                protected override void Start()
                {
                    base.Start();
                }
                public override void Shoot()
                {
                    fwd = rifleBarrel.TransformDirection(Vector3.forward);
                    Instantiate(line.gameObject, rifleBarrel.position, Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0));

                    if (Physics.Raycast(rifleBarrel.position, fwd, out hit, 50))
                    {
                        if (hit.collider.gameObject.layer == LayerMask.NameToLayer("enemy"))
                            Destroy(hit.collider.transform.parent.gameObject);
                    }
                }
            }
        }
    }
}