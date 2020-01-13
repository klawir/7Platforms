using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Avoidance : MonoBehaviour
{
    public NavMeshObstacle obstacle;

    public void Enable()
    {
        obstacle.enabled = true;
    }
    public void Disable()
    {
        obstacle.enabled = false;
    }
}