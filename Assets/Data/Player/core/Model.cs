using UnityEngine;

public class Model : MonoBehaviour
{
    public Rigidbody rigidbody;
    public Transform root;
    public Abilities abilities;
    public AnimManager animManager;
    public string TerrainName;

    public float gravity;
    private bool isGrounded;

    private void Update()
    {
        if (!(Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.D)) &&
            !(Input.GetMouseButton(0)))
            animManager.Idle();

        if (IsInTheAir)
        {
            root.Translate(Move.movementVector);
            animManager.Go();
            if (IsAskew)
                UpdateRotation();
        }
    }
    void FixedUpdate()
    {
        rigidbody.AddForce(Vector3.down * gravity);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == TerrainName)
        {
            isGrounded = true;
            Move.Reset();
        }
    }
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.name == TerrainName)
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
        get { return transform.rotation.x != 0; }
    }

    public bool IsGrounded
    {
        get { return isGrounded; }
    }
}