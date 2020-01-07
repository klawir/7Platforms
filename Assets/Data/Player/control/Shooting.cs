using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Bullet bullet;
    public Transform rifleBarrel;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            GameObject tempObj = Instantiate(bullet.gameObject, rifleBarrel.position, bullet.transform.rotation) as GameObject;
            tempObj.GetComponent<Bullet>().Start(rifleBarrel);
        }
    }
}
