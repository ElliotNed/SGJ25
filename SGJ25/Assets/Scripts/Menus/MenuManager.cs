using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public string levelToLoad;
    public GameObject infosWindow;
    public GameObject mainMenu;

    public void Play()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void Infos()
    {
        infosWindow.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void CloseInfos()
    {
        infosWindow.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
