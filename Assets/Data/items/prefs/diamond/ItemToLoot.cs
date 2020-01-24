using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemToLoot : DetectorController
{
    public GameObject root;
    public Reward reward;
    public Combat player;
    public Congratulations Congratulations;
    public Items.ToTake.GUI gui;

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
            gui.EnableInfo();
            gui.RenderDefault();
            if (Input.GetKeyDown(KeyCode.E))
                Destroy(root);
        }
    }
    void OnDestroy()
    {
        gui.DisableInfo();
        player.score.Add(reward);
        Congratulations.enabled = true;
    }
}