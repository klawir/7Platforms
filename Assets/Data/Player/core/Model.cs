using Player.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    public Transform hand;
    public GameObject key;
    public Rigidbody rigidbody;
    public Atributes player;

    public float gravity;
    private bool isGrounded;
    private bool keyJumpWall;

    private void Update()
    {  
        if (IsInTheAir || keyJumpWall)
        {
            player.UpdatePos();
            if(IsAskew)
                UpdateRotation();
        }
        if (isGrounded)
            KeyJumpWallFaded();
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
    public bool IsInTheAir
    {
        get { return !isGrounded; }
    }
    private bool IsAskew
    {
        get { return transform.rotation.x!=0; }
    }
    public void WallJump()
    {
        Move.WallJump();
        keyJumpWall = true;
    }
    public void TakeKey()
    {
        Instantiate(key, hand);
    }
    public void KeyJumpWallFaded()
    {
        keyJumpWall=false;
    }
    public bool HasKey
    {
        get { return hand.childCount > 0; }
    }
    public bool IsGrounded
    {
        get { return isGrounded; }
    }
}