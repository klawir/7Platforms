using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ZombieDataToSave
{
    public float hp;

    public ZombieDataToSave(GameObject model)
    {
        Health health= model.GetComponentInChildren<Health>();
        this.hp = health.current;
    }
}
