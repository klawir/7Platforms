using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTerrain : MonoBehaviour
{
    private bool playerDetected;
    private Health detectedPlayer;
    public ZombieSpawnManager spawnManager;
    public Transform zombieSpawnPoint;
    public int zombieLimit;
    public string playerTag;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag(playerTag))
        {
            playerDetected = true;
            detectedPlayer = col.transform.parent.GetComponentInChildren<Health>();
            if (!IsZombieLimit)
                spawnManager.Spawn();
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag(playerTag))
        {
            playerDetected = false;
            detectedPlayer = null;
        }
    }
    private bool IsZombieLimit
    {
        get { return zombieSpawnPoint.childCount >= zombieLimit; }
    }
    public bool IsPlayerDetected
    {
        get { return playerDetected; }
    }
    public Health DetectedPlayer
    {
        get { return detectedPlayer; }
    }
}
