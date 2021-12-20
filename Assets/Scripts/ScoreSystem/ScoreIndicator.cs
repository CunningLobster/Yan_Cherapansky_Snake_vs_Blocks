using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ScoreSystem
{
    public class ScoreIndicator : MonoBehaviour
    {
        public int score;
        TMP_Text scoreText;

        public const string bestScoreKey = "BestScore";

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
            score++;

            int currentHighScore = PlayerPrefs.GetInt(bestScoreKey, 0);

            if (score > currentHighScore)
            {
                PlayerPrefs.SetInt(bestScoreKey, score);
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
    }
}
