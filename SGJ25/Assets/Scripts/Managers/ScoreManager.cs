using UnityEngine;

public static class ScoreManager
{
    public static int score = 100;

    public static void Victory()
    {
        score += 5;
    }

    public static void Loose()
    {
        score -= 5;
    }
}
