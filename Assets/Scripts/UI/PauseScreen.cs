using UnityEngine;
using UnityEngine.SceneManagement;//To Fix


namespace UI
{
    public class PauseScreen : MonoBehaviour
    {
        private void OnEnable()
        {
            Time.timeScale = 0;
        }

        private void OnDisable()
        {
            Time.timeScale = 1f;
        }

        public void Continue()
        {
            Time.timeScale = 1.0f;
        }

        public void LoadMainMenu()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
