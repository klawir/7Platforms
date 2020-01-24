using UnityEngine;

namespace Player
{
    public class Model : MonoBehaviour
    {
        public Transform waist;
        public GameObject key;
        public Rigidbody rigidbody;
        public Transform root;
        public Abilities abilities;
        public Health health;
        public GUI gui;
        public string name;
        public AnimManager animManager;

        public float gravity;
        private bool isGrounded;

        public void Awake()
        {
            gui.UpdateGUIKeysCollections(waist);
            LoadName();
        }
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
            get { return transform.rotation.x != 0; }
        }
        public void TakeKey()
        {
            Instantiate(key, waist);
            gui.UpdateGUIKeysCollections(waist);
        }

        public bool HasKeys
        {
            get { return waist.childCount >= 5; }
        }
        public int KeyNumber
        {
            get { return waist.childCount; }
        }
        public bool IsGrounded
        {
            get { return isGrounded; }
        }


        public void LoadName()
        {
            name = RememberUserData.Name;
            gui.UpdateName(name);
        }
        public void LoadGameState()
        {
            gui.UpdateName(name);
            gui.UpdateHealth(health);
        }
    }
}