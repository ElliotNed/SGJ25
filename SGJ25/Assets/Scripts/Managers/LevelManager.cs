using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelManager
{
    public static int[] levels = new int[] { 1, 2, 3, 4 }; //all levels index (last one = thanks for playing screen)

    public static void NextLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (currentLevel < levels.Length)
        {
            SceneManager.LoadScene(currentLevel+1);
        }
        if (currentLevel == levels.Length)
        {
            ScoreManager.ResetScore();
            SceneManager.LoadScene(0);
        }
    }
}
