using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public Rigidbody momentum;
    public float speed;
    public GameObject effect;
    protected GameObject target;

    public virtual void Momentum(Transform rifleBarrel)
    {
        momentum.velocity = rifleBarrel.transform.forward * speed;
    }

    protected abstract void OnTriggerEnter(Collider other);
}
