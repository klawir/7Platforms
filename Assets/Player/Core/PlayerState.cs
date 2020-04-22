using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public AnimManager animManager;

    private void Update()
    {
        if (IsIdle)
            animManager.Idle();
    }

    private bool IsIdle
    {
        get
        {
            return !(Input.GetKey(KeyCode.W)
                || Input.GetKey(KeyCode.A)
                || Input.GetKey(KeyCode.S)
                || Input.GetKey(KeyCode.D)) && !(Input.GetMouseButton(0));
        }
    }
}
