using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTerrain : MonoBehaviour
{
    private bool playerDetected;
    private GameObject detectedPlayer;
    public ZombieSpawnManager spawnManager;
    public Transform zombieSpawnPoint;
    public int zombieLimit;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer==8)
        {
            playerDetected = true;
            detectedPlayer = collision.gameObject;
            if(!IsZombieLimit)
                spawnManager.Spawn();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 8)
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
    public Vector3 DetectedPlayerPos
    {
        get { return detectedPlayer.transform.position; }
    }
    public GameObject DetectedPlayer
    {
        get { return detectedPlayer; }
    }
}
