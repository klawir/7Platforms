using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public Transform rifleBarrel;
    public float speedAttack;
    protected Delay delay;
    public AudioSource audio;

    protected virtual void Start()
    {
        delay = new Delay();
    }

    public abstract void Shoot();
}