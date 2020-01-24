using Player;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestController : DetectorController
{
    private Model player;
    public Items.ToUse.GUI gui;
    public List <Collider> col;
    public GameObject loot;
    public Transform up;

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
                if (IsClosed)
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
            if (IsOpened)
                gui.RenderDefault();
            else if (IsClosed)
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
        if (IsOpened)
        {
            Close();
            loot.SetActive(false);
        }
    }

    private void SetStateToOpened()
    {
        doorState = DoorState.Opened;
    }
    private void SetStateToClosed()
    {
        doorState = DoorState.Closed;
    }
    private bool IsOpened
    {
        get { return doorState == DoorState.Opened; }
    }
    private bool IsClosed
    {
        get { return doorState == DoorState.Closed; }
    }
    private void Open()
    {
        up.rotation = Quaternion.Euler(0, -90, -90);
    }
    private void Close()
    {
        up.rotation = Quaternion.Euler(0, -90, 0);
        SetStateToClosed();
    }
}
