using Platforms;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void Restart()
    {
        Snake snake = FindObjectOfType<Snake>(true);
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
