using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looking : MonoBehaviour
{
    public Transform playerModel;

    void Update()
    {
        Vector3 mouse = Input.mousePosition;
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(new Vector3(
                                                            mouse.x,
                                                            mouse.y,
                                                            playerModel.position.y));
        Vector3 forward = mouseWorld - playerModel.position;
        playerModel.rotation = Quaternion.LookRotation(forward, Vector3.up);
    }
}
