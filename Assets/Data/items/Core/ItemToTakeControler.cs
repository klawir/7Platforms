using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemToTakeControler : DetectorController
{
    public Items.ToTake.GUI gui;
    public GameObject root;

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        gui.EnableInfo();
        gui.RenderDefault();
    }
    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
        gui.DisableInfo();
    }
    protected virtual void Update()
    {
        if (playerInZone)
        {
            if (Input.GetKeyDown(KeyCode.E))
                Destroy(root);
        }
    }
    protected virtual void OnDestroy()
    {
        gui.DisableInfo();
    }
}
