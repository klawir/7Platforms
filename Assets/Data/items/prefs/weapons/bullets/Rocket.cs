using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Bullet
{
    public GameObject explosion;
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
        if (other.CompareTag("enemy"))
            explosion.SetActive(true);
    }
}
