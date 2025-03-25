using UnityEngine;

public static class ScoreManager
{
    public static int score = 0;
    public static float timerStart;
    public static float levelTime;

    public static void StartTimer()
    {
        timerStart = Time.time;
    }

    public static void AddScore()
    {
        levelTime = Time.time - timerStart;
        switch(levelTime)
        {
            case < 20:
                score+=30;
                break;

            case < 40:
                score+=20;
                break;

            case < 60:
                score+=10;
                break;

            case > 60:
                score+=5;
                break;
        }
    }
}
