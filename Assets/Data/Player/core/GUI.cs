using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class GUI : MonoBehaviour
    {
        public Text doubleJump;
        public Text sprint;
        public Text keysCollections;
        public Text name;
        public Text health;

        public Model model;

        public void UpdateName(string value)
        {
            name.text = value;
        }
        public void UpdateGUIKeysCollections(Transform hand)
        {
            keysCollections.text = "keys: " + hand.childCount;
        }
        public void UpdateHealth(Health health)
        {
            this.health.text = health.current.ToString();
        }
        public void DoubleJumpUnlock()
        {
            doubleJump.color = Color.green;
        }
        public void SprintUnlock()
        {
            sprint.color = Color.green;
        }
    }
}