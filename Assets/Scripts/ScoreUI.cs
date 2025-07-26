using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public static ScoreUI instance;
    public TMP_Text scoreText;
    public TMP_Text highscoreText;
    int score = 0;
    int highscore = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString() + " POINTS";
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
    }

    // Update is called once per frame
    public void AddPoint()
    {
        score += 1;
        scoreText.text = score.ToString() + " POINTS";
    }
    private void Awake()
    {
        instance = this;
    }
}
