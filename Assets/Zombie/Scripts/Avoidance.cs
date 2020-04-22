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
    public bool IsObstacleEnable
    {
        get { return obstacle.enabled; }
    }
    public void GoToPosition(Vector3 pos)
    {
        transform.position = pos;
    }
}