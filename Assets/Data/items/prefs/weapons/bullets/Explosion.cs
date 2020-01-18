using Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : BulletDecorator
{
    public int dmg;

    public Explosion(Bullet bullet) : base(bullet)
    {
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            Debug.Log("3");
            target = other.gameObject;
            other.GetComponent<BaseCombat>().TakeDmg(dmg);
            Destroy(transform.parent.gameObject);
        }
    }
    private void OnDestroy()
    {
        Instantiate(effect, target.transform);
    }
}
