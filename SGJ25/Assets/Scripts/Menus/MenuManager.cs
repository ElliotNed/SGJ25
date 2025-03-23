using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public string levelToLoad;
    public GameObject infosWindow;

    public void Play()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void Infos()
    {
        infosWindow.SetActive(true);
    }

    public void CloseInfos()
    {
        infosWindow.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
