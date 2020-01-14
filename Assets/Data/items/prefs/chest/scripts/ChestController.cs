using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestController : DetectorController
{
    private Model player;
    public Items.ToUse.GUI gui;
    public GameObject up;
    public List <Collider> col;
    public GameObject loot;

    enum DoorState
    {
        Closed,
        Opened
    }

    DoorState doorState = new DoorState();
    
    void Start()
    {
        SetStateToClosed();
    }
    void Update()
    {
        if (playerInZone)
        {
            if (Input.GetKeyDown(KeyCode.E) && player.HasKeys)
            {
                if (doorState == DoorState.Closed)
                {
                    SetStateToOpened();
                    Open();
                    loot.SetActive(true);
                    gui.DisableInfoState();
                }
            }
        }
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
       
        if (other.CompareTag("player"))
        {
            player = other.GetComponent<Model>();
            if (doorState == DoorState.Opened)
                gui.RenderDefault();
            else if (doorState == DoorState.Closed)
            {
                gui.RenderOpen();
                if (!player.HasKeys)
                {
                    gui.EnableInfoState();
                    gui.RenderState();
                }
            }
            gui.EnableInfo();
        }
    }
    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
        gui.DisableInfoState();
        gui.DisableInfo();
    }

    private void SetStateToOpened()
    {
        doorState = DoorState.Opened;
    }
    private void SetStateToClosed()
    {
        doorState = DoorState.Closed;
    }
    private void Open()
    {
        up.SetActive(false);
        foreach (Collider _col in col)
            _col.enabled=false;
    }
}
