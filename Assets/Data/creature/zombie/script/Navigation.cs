using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigation : MonoBehaviour
{
    public PlatformTerrain platform;
    public NavMeshAgent agent;
    public Avoidance avoidance;
    public AnimManager animManager;
    public Combat combat;
    public Transform model;

    private Vector3 pos;
    public float positionLerping;

    private void Update()
    {
        if (!combat.IsDead)
        {
            if (platform.IsPlayerDetected)
            {
                if (combat.IsPlayerInRange)
                {
                    if (agent.enabled)
                    {
                        avoidance.Enable();
                        Disable();
                    }
                }
                else
                {
                    if (agent.enabled)
                        Go();
                    else
                    {
                        if (!avoidance.IsObstacleEnable)
                            Enable();
                        else
                            avoidance.Disable();
                    }
                }
            }

            else
            {
                animManager.Idle();
                if (agent.enabled)
                {
                    avoidance.Enable();
                    Disable();
                }
            }
        }
    }
    public void Enable()
    {
        agent.enabled = true;
    }
    public void Disable()
    {
        agent.enabled = false;
    }

    private void Go()
    {
        InitPlayersPos();
        animManager.Go();
        Moving(agent);
        avoidance.GoToPosition(pos);
    }
    private void Moving(NavMeshAgent agent)
    {
        model.position = Vector3.Lerp(model.position, agent.transform.position, Time.deltaTime * positionLerping);
        model.rotation = agent.transform.rotation;
    }
    private void InitPlayersPos()
    {
        agent.destination = platform.DetectedPlayer.transform.position;
    }
}