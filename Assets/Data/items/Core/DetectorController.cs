using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class DetectorController : MonoBehaviour
{
    protected bool playerInZone;
    
    protected virtual void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("player"))
            playerInZone = true;
    }
    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
            playerInZone = false;
    }
}
