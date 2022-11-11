using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager _instance { get; set; }

    public TMP_Text txtScore;

    private int score;

    private void Awake()
    {
        if (_instance == null) _instance = this;
        else Destroy(gameObject);

        score = 0;
    }

    public void UpdateScore(int change)
    {
        score += change;
        txtScore.text = "Score: " + score.ToString();
    }

}
