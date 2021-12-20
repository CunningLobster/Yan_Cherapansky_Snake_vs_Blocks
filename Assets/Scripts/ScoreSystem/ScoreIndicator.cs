using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ScoreSystem
{
    public class ScoreIndicator : MonoBehaviour
    {
        public int score;
        private int bestScore;
        TMP_Text scoreText;

        private void Awake()
        {
            scoreText = GetComponent<TMP_Text>();
        }

        private void Update()
        {
            scoreText.text = score.ToString();
        }

        public void AddScore()
        {
            print("add score");
            score++;
            if (score > bestScore)
            { 
                bestScore = score;
            }
        }

        public void ResetScore()
        {
            score = 0;
        }

        public int GetScore()
        { 
            return score;
        }

        public int GetBestScore()
        { 
            return bestScore;
        }
    }
}
