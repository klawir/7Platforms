using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemToLoot : ItemToInterractDetector
{
    public GameObject root;
    public Reward reward;
    public Score player;
    public Congratulations Congratulations;

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        player = other.transform.parent.GetComponentInChildren<Score>();
    }
    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
    }
    protected virtual void Update()
    {
        if (playerInZone)
        {
            EnableInterractKeyInfo();
            BasicGUIText();
            if (Input.GetKeyDown(KeyCode.E))
                Destroy(root);
        }
    }
    public override void BasicGUIText()
    {
        interractKeyInfo.text = GUITextInterract;
    }
    void OnDestroy()
    {
        DisableInterractKeyInfo();
        player.Add(reward);
        Congratulations.enabled = true;
    }
}