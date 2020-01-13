using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemToLoot : DetectorController
{
    public GameObject root;
    public Reward reward;
    public Combat player;
    public Congratulations Congratulations;

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        player = other.GetComponent<Combat>();
    }
    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
    }
    protected virtual void Update()
    {
        if (playerInZone)
        {
            if (Input.GetKeyDown(KeyCode.E))
                Destroy(root);
        }
    }
    void OnDestroy()
    {
        player.score.Add(reward);
        Congratulations.enabled = true;
    }
}