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
            bestScoreField.text = $"Best - {FindObjectOfType<ScoreIndicator>().GetBestScore().ToString()}";
        }

        public void Play()
        {
            FindObjectOfType<SnakeBuilder>().GetComponent<SnakeMover>().enabled = true;
            gameObject.SetActive(false);
        }
    }
}
