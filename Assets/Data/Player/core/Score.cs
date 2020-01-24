using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Score : MonoBehaviour
    {
        private int amount;
        public GUI gui;

        private void Awake()
        {
            amount = 0;
            gui.UpdateScore(amount);
        }
        public void Add(Reward value)
        {
            this.amount += value.score;
            gui.UpdateScore(amount);
        }
        public void Remove(int value)
        {
            this.amount -= value;
            gui.UpdateScore(amount);
        }
        public int Value
        {
            get { return amount; }
            set { amount = value; }
        }
    }
}