using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTerrain : MonoBehaviour
{
    private bool playerDetected;
    private BaseCombat detectedPlayer;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer==8)
        {
            playerDetected = true;
            detectedPlayer = collision.gameObject.GetComponent<BaseCombat>();
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

    public bool IsPlayerDetected
    {
        get { return playerDetected; }
    }
    public Vector3 DetectedPlayerPos
    {
        get { return detectedPlayer.transform.position; }
    }
    public BaseCombat DetectedPlayer
    {
        get { return detectedPlayer; }
    }
}
