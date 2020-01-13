using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ScoreBoard
{
    public class Board : MonoBehaviour
    {
        public GameState gameState;
        private int counter;
        public Score score;

        void Start()
        {
            gameState.Load(score);
            counter = 1;
            score.Load(counter, gameState);
            Instantiate(score, transform);
        }
    }
}
