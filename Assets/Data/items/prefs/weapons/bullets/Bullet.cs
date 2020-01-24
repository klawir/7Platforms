using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public Rigidbody momentum;
    public float speed;
    public GameObject effect;
    protected Collider target;

    public virtual void Momentum(Transform rifleBarrel)
    {
        momentum.velocity = rifleBarrel.transform.forward * speed;
    }
    protected virtual void Update()
    {
        if (transform.position.y < 0)
            Destroy(gameObject);
    }

    protected abstract void OnTriggerEnter(Collider other);
}
