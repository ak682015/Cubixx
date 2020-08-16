using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public Text scoreText;
    public TextMeshProUGUI bestScore;

    private void Awake()
    {
        score = 0;
        bestScore.text = PlayerPrefs.GetInt("bestscore", 0).ToString();
    }


    private void FixedUpdate()
    {
        if(Time.frameCount % 3 == 0)
        {
            score++;
            scoreText.text = score.ToString("0");
            if (score > PlayerPrefs.GetInt("bestscore", 0))
            {
                PlayerPrefs.SetInt("bestscore", score);
            }
        }
    }
}
