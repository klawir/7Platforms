using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DetectorController : MonoBehaviour
{
    protected bool playerInZone;
    public string playerTag;

    protected virtual void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(playerTag))
            playerInZone = true;
    }
    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(playerTag))
            playerInZone = false;
    }
}
