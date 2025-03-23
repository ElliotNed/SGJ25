using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelManager
{
    public static int[] levels = new int[] { 1, 2 }; //all levels index

    public static void NextLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (currentLevel < levels.Length)
        {
            SceneManager.LoadScene(currentLevel+1);
        }
        if (currentLevel == levels.Length)
        {
            SceneManager.LoadScene(0);
        }
    }
}
