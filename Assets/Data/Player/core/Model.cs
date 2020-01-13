using Player.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Model : MonoBehaviour
{
    public Transform hand;
    public GameObject key;
    public Rigidbody rigidbody;
    public Atributes player;
    public Abilities abilities;
    public Text doubleJump;
    public Text sprint;
    public Text keysCollections;
    public Text GUIname;
    public string name;
    
    public float gravity;
    private bool isGrounded;

    public void Awake()
    {
        UpdateGUIKeysCollections();
        UpdateNameNoLoadedDataFromFile();
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
    public void UpdateNameNoLoadedDataFromFile()
    {
        name = RememberUserData.Name;
        GUIname.text = name;
    }
    public void UpdateName()
    {
        GUIname.text = name;
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
        UpdateGUIKeysCollections();
    }
    private void UpdateGUIKeysCollections()
    {
        keysCollections.text = "keys: "+hand.childCount;
    }
    public void UnlockDoubleJump()
    {
        abilities.jump.Unlock();
        doubleJump.color = Color.green;
    }
    public void UnlockSprint()
    {
        abilities.sprint.Unlock();
        sprint.color = Color.green;
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