using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody projectile;
    public float speed;

    public void Start(Transform rifleBarrel)
    {
        projectile.velocity = rifleBarrel.transform.forward * speed;
    }
}
