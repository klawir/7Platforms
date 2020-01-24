using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class GUI : MonoBehaviour
    {
        public Image doubleJump;
        public Image sprint;
        public Text keysCollections;
        public Text name;
        public Text health;
        public Text score;
        public Image fastShooting;
        public Image rayGun;
        public Image bazooke;

        public Model model;

        public void SelectFastShooting()
        {
            fastShooting.color = Color.green;
            DeselectRayGun();
            DeselectBazooke();
        }
        public void SelectRayGun()
        {
            rayGun.color = Color.green;
            DeselectFastShooting();
            DeselectBazooke();
        }
        public void SelectBazooke()
        {
            bazooke.color = Color.green;
            DeselectFastShooting();
            DeselectRayGun();
        }
        private void DeselectFastShooting()
        {
            fastShooting.color = Color.white;
        }
        private void DeselectRayGun()
        {
            rayGun.color = Color.white;
        }
        private void DeselectBazooke()
        {
            bazooke.color = Color.white;
        }
        public void UpdateScore(int value)
        {
            score.text = value.ToString();
        }
        public void UpdateScore(GameState gameState)
        {
            score.text = gameState.GameDataState.score.ToString();
        }
        public void UpdateName(string value)
        {
            name.text = value;
        }
        public void UpdateGUIKeysCollections(Transform hand)
        {
            keysCollections.text = hand.childCount.ToString();
        }
        public void UpdateHealth(Health health)
        {
            this.health.text = health.current.ToString();
        }
        public void DoubleJumpUnlock()
        {
            doubleJump.enabled = true;
        }
        public void SprintUnlock()
        {
            sprint.enabled = true;
        }
    }
}