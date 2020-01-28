
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Bullet
{
    public int dmg;

    protected override void Update()
    {
        base.Update();
    }
    public override void Momentum(Transform rifleBarrel)
    {
        base.Momentum(rifleBarrel);
    }
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(enemyTag))
        {
            target = other;
            target.gameObject.GetComponent<Health>().Remove(dmg);
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        Instantiate(effect, target.bounds.center, Quaternion.Inverse(target.transform.rotation));
    }
}
