using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int score;
    public TextMeshProUGUI ScoreText;
    [SerializeField] int HighScore;
    public TextMeshProUGUI HighScoreText;
    private void Start()
    {
        HighScore = PlayerPrefs.GetInt("highscore");
    }
    public void GetScore()
    {
        score++;
        ScoreText.text = score.ToString();
    }
    public void GetHighScore()
    {
        HighScoreText.text = HighScore.ToString();

        if (score > HighScore)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }
}
