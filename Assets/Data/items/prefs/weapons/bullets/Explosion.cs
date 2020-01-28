using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : BulletDecorator
{
    public int dmg;

    protected override void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag(enemyTag))
        {
            target = col;
            col.gameObject.GetComponent<Health>().Remove(dmg);
            Destroy(transform.parent.gameObject);
        }
    }
    private void OnDestroy()
    {
        Instantiate(effect, target.bounds.center, Quaternion.identity);
    }
}
