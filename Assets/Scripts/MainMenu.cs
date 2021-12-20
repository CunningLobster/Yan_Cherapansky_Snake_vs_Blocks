using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        FindObjectOfType<Snake>().GetComponent<SnakeMover>().enabled = true;
        gameObject.SetActive(false);
    }
}
