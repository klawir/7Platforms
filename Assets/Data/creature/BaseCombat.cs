using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCombat : MonoBehaviour
{
    public Health health;

    protected virtual void Update()
    {
        if (health.IsDead)
            Die();
    }
    protected virtual void Die()
    {
        Destroy(gameObject);
    }
    public virtual void TakeDmg(int dmg)
    {
        health.current -= dmg;
    }
}
