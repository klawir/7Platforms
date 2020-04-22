using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public static Vector3 movementVector;

    public static void Reset()
    {
        movementVector = Vector3.zero;
    }
    
    private static void StopMovement()
    {
        movementVector = Vector3.zero;
    }
}
