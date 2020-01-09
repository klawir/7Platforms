using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : MonoBehaviour
{
    private float nextActionTime;
    private float frequency;

    public Delay()
    {
        frequency = 1f;
    }
    public Delay(float period)
    {
        this.frequency = period;
    }

    public bool IsOver
    {
        get { return Time.time > nextActionTime; }
    }
    public void Init()
    {
        nextActionTime += frequency;
    }
    public void Init(float value)
    {
        nextActionTime += value;
    }
}
