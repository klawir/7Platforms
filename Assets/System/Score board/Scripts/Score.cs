﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ScoreBoard
{
    public class Score : MonoBehaviour
    {
        public Text number;
        public Text name;
        public Text points;
        public Text time;

        public void Load(int number, GameState gameState)
        {
            this.number.text = number.ToString();
            name.text = gameState.GameDataState.name;
            points.text = gameState.GameDataState.score.ToString();
            time.text = gameState.GameDataState.gameTime.ToString();
        }
    }
}