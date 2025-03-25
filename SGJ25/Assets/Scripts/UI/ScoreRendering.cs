using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreRendering : MonoBehaviour
{
    private TMP_Text scoreText;
    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        ScoreManager.StartTimer();
    }

    void Update()
    {
        scoreText.text = ScoreManager.score.ToString();
    }
}
