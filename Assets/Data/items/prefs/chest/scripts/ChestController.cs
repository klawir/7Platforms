using UnityEngine;
using UnityEngine.UI;

public class ChestController : DetectorController
{
    private Model player;
    public Items.ToUse.GUI gui;

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
                if (!player.HasKey)
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
}
