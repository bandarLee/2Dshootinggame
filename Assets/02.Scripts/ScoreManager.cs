using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Drawing;


public class ScoreManager : MonoBehaviour
{
    private int _score = 0;
    public int Score
    {
        get { return _score; }
        set { _score = value; }
    }
    public TMP_Text Point;
    public TMP_Text BestScoreTextUI;
    public int BestScore = 0;
    public static ScoreManager Instance;


    private void Awake()
    {
        // 싱글톤 패턴 : 오직 한개의 클래스 인스턴스를 갖도록 보장
        if( Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
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
    

}
