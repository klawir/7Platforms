using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class Score : MonoBehaviour
    {
        private int amount;
        public Text gui;

        private void Awake()
        {
            amount = 0;
            UpdateGUI();
        }
        public void Add(Reward value)
        {
            this.amount += value.score;
            UpdateGUI();
        }
        public void Remove(int value)
        {
            this.amount -= value;
            UpdateGUI();
        }
        private void UpdateGUI()
        {
            gui.text = amount.ToString();
        }
        public void UpdateGUI(DataToSave gameState)
        {
            gui.text = gameState.score.ToString();
        }
        public int Value
        {
            get { return amount; }
            set { amount = value; }
        }
    }
}