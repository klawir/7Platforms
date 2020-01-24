using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTerrain : MonoBehaviour
{
    private bool playerDetected;
    private BaseCombat detectedPlayer;
    public ZombieSpawnManager spawnManager;
    public Transform zombieSpawnPoint;
    public int zombieLimit;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            playerDetected = true;
            detectedPlayer = collision.gameObject.GetComponent<BaseCombat>();
            if (!IsZombieLimit)
                spawnManager.Spawn();
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("player"))
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
    public BaseCombat DetectedPlayer
    {
        get { return detectedPlayer; }
    }
}
