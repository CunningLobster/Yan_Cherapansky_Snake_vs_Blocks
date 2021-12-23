using ScoreSystem;
using Snake;
using TMPro;
using UnityEngine;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] TMP_Text bestScoreField;

        private void Awake()
        {
            bestScoreField.text = $"Best - {PlayerPrefs.GetInt(ScoreIndicator.bestScoreKey, 0)}";
        }

        public void Play()
        {
            FindObjectOfType<ScoreIndicator>(true).gameObject.SetActive(true);
            FindObjectOfType<SnakeBuilder>().GetComponent<SnakeMover>().enabled = true;
            FindObjectOfType<PauseActivator>(true).gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
