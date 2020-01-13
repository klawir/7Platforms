using Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : BulletDecorator
{
    public int dmg;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public Explosion(Bullet bullet) : base(bullet)
    {
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            other.GetComponent<BaseCombat>().TakeDmg(dmg);
            Destroy(transform.root.gameObject);
        }
    }
}
