using Player;
using UnityEngine;

public class Model : MonoBehaviour
{
    public Transform hand;
    public GameObject key;
    public Rigidbody rigidbody;
    public Atributes player;
    public Abilities abilities;
    public Health health;
    public Player.GUI gui;
    public string name;
    
    public float gravity;
    private bool isGrounded;

    public void Awake()
    {
        gui.UpdateGUIKeysCollections(hand);
        LoadName();
    }
    private void Update()
    {  
        if (IsInTheAir)
        {
            player.UpdatePos();
            if(IsAskew)
                UpdateRotation();
        }
    }
    void FixedUpdate()
    {
        rigidbody.AddForce(Vector3.down * gravity * rigidbody.mass);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Terrain")
        {
            isGrounded = true;
            Move.Reset();
        }
    }
    
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.name == "Terrain")
            isGrounded = false;
    }
    
    public void UpdateRotation()
    {
        transform.rotation = Quaternion.LookRotation(Move.movementVector);
    }
    public void LoadName()
    {
        name = RememberUserData.Name;
        gui.UpdateName(name);
    }
    public void LoadSavedData()
    {
        gui.UpdateName(name);
        gui.UpdateHealth(health);
    }
    public bool IsInTheAir
    {
        get { return !isGrounded; }
    }
    private bool IsAskew
    {
        get { return transform.rotation.x!=0; }
    }
    public void TakeKey()
    {
        Instantiate(key, hand);
        gui.UpdateGUIKeysCollections(hand);
    }
    
    public void UnlockDoubleJump()
    {
        abilities.jump.Unlock();
        gui.DoubleJumpUnlock();
    }
    public void UnlockSprint()
    {
        abilities.sprint.Unlock();
        gui.SprintUnlock();
    }

    public bool HasKeys
    {
        get { return hand.childCount == 5; }
    }
    public int KeyNumber
    {
        get { return hand.childCount; }
    }
    public bool IsGrounded
    {
        get { return isGrounded; }
    }
}