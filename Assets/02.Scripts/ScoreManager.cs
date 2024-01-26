using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Drawing;


public class ScoreManager : MonoBehaviour
{
    public int point = 0;

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

        Point.text = $"{point:D6}";
        if (BestScore < point)
        {
            BestScore = point;
        }
        BestScoreTextUI.text = $"{BestScore:D6}";
    }

}
