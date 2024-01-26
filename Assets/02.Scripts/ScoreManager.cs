using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Drawing;


public class ScoreManager : MonoBehaviour
{
    private int _score = 0;

    public TMP_Text Point;
    public TMP_Text BestScoreTextUI;
    public int BestScore = 0;
    void Start()
    {
        BestScore = PlayerPrefs.GetInt("BestScore", 0);
    }

    private void Update()
    {
        //playerprefab을 사용할것임.
        PlayerPrefs.SetInt("BestScore", BestScore);

        Point.text = $"{_score:D6}";
        if (BestScore < _score)
        {
            BestScore = _score;
        }
        BestScoreTextUI.text = $"{BestScore:D6}";
    }
    //목표 : score 속성에 대한 캡슐화(get/set)
    public int GetScore()
    {
        return _score;
    }
    public void SetScore(int score)
    {
        if (score < 0)
        {
            return;
        }
        _score = score;
    }

}
