using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ScoreBoard
{
    public class Score : MonoBehaviour
    {
        public Text numer;
        public Text name;
        public Text points;
        public Text time;

        public void Load(int number, GameState gameState)
        {
            numer.text = number.ToString();
            name.text = gameState.Score.name;
            points.text = gameState.Score.score.ToString();
            time.text = gameState.Score.gameTime.ToString();
        }
    }
}