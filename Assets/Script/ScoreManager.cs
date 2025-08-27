using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int score;
    public TextMeshProUGUI ScoreNum;
    [SerializeField] int HighScore;
    public TextMeshProUGUI HighScoreNum;
    private void Start()
    {
        HighScore = PlayerPrefs.GetInt("highscore");
    }
    public void GetScore()
    {
        score++;
        ScoreNum.text = score.ToString();
    }
    public void GetHighScore()
    {
        HighScoreNum.text = HighScore.ToString();

        if (score > HighScore)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }
}
