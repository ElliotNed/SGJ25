using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public string levelToLoad;
    public GameObject settingsWindow;

    public void Play()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void Option()
    {
        settingsWindow.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsWindow.SetActive(false);
    }
        

    public void Quit()
    {
        Application.Quit();
    }
}
