using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : MonoBehaviour
{
    private float nextActionTime;

    public Delay()
    {
        nextActionTime = 0;
    }

    public bool IsOver
    {
        get { return Time.time > nextActionTime; }
    }
    public void Init(float value)
    {
        nextActionTime = Time.time+value;
    }
}
