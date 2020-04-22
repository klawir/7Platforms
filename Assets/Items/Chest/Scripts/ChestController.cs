using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestController : ItemToInterractDetector
{
    private KeyCollection player;
    public GameObject loot;
    public Transform up;
    public Text GUIrequirementsToOpen;
    private State state;
    public string GUITextRequirementsToOpen;
    public string GUITextStateToOpen;
    
    enum State
    {
        Closed,
        Opened
    }

    void Start()
    {
        SetStateToClosed();
        state = new State();
    }
    
    void Update()
    {
        if (playerInZone)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(player.HasKeys)
                {
                    SetStateToOpened();
                    Open();
                    loot.SetActive(true);
                    DisableGUIrequirementsToOpen();
                }
            }
        }
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
       
        if (other.CompareTag(playerTag))
        {
            player = other.transform.parent.GetComponentInChildren<KeyCollection>();
            if (IsOpened)
                BasicGUIText();
            else if (IsClosed)
            {
                RenderOpen();
                if (!player.HasKeys)
                {
                    EnableGUIrequirementsToOpen();
                    RenderState();
                }
            }
            EnableInterractKeyInfo();
        }
    }
    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
        DisableGUIrequirementsToOpen();
        DisableInterractKeyInfo();
        if (IsOpened)
        {
            Close();
            loot.SetActive(false);
        }
    }
    
    public override void BasicGUIText()
    {
        interractKeyInfo.text = GUITextInterract;
    }
    public void RenderOpen()
    {
        interractKeyInfo.text = GUITextStateToOpen;
    }
    public void RenderState()
    {
        GUIrequirementsToOpen.text = GUITextRequirementsToOpen;
    }
    public void EnableGUIrequirementsToOpen()
    {
        GUIrequirementsToOpen.gameObject.SetActive(true);
    }
    public void DisableGUIrequirementsToOpen()
    {
        GUIrequirementsToOpen.gameObject.SetActive(false);
    }

    private void SetStateToOpened()
    {
        state = State.Opened;
    }
    private void SetStateToClosed()
    {
        state = State.Closed;
    }
    private bool IsOpened
    {
        get { return state == State.Opened; }
    }
    private bool IsClosed
    {
        get { return state == State.Closed; }
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
