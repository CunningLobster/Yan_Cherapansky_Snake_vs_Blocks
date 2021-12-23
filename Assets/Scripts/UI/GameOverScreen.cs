using Platforms;
using Snake;
using ScoreSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace UI
{
    public class GameOverScreen : MonoBehaviour
    {
        [SerializeField] TMP_Text scoreField;
        [SerializeField] TMP_Text bestScoreField;

        private void OnEnable()
        {
            scoreField.text = $"Score : {FindObjectOfType<ScoreIndicator>(true).GetScore().ToString()}";
            bestScoreField.text = $"Best : {PlayerPrefs.GetInt(ScoreIndicator.bestScoreKey, 0)}";

            FindObjectOfType<ScoreIndicator>(true).ResetScore();
            FindObjectOfType<ScoreIndicator>(true).gameObject.SetActive(false);
        }

        public void Restart()
        {
            FindObjectOfType<ScoreIndicator>(true).gameObject.SetActive(true);

            SnakeBuilder snake = FindObjectOfType<SnakeBuilder>(true);
            snake.RebuildSnake();

            PlatformSpawner platformSpawner = FindObjectOfType<PlatformSpawner>();
            platformSpawner.RebuildLevel();

            gameObject.SetActive(false);
        }
        public void LoadMainMenu()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
