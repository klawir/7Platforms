using Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Bullet
{
    public int dmg;

    public override void Momentum(Transform rifleBarrel)
    {
        base.Momentum(rifleBarrel);
    }
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            other.GetComponent<BaseCombat>().TakeDmg(dmg);
            Destroy(gameObject);
        }
    }
}
