using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public string levelToLoad;
    public static bool isPaused = false;
    public GameObject pauseMenuUI;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
    }
    public void Paused()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        isPaused = true;
    }

    public void MainMenu()
    {
        Resume();
        SceneManager.LoadScene(levelToLoad);
    }
}
