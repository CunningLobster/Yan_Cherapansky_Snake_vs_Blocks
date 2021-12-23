using UnityEngine;
using UnityEngine.SceneManagement;


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
            gameObject.SetActive(false);
        }

        public void LoadMainMenu()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
