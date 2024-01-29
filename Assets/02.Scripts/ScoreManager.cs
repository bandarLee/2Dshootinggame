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
        // �̱��� ���� : ���� �Ѱ��� Ŭ���� �ν��Ͻ��� ������ ����
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
        //playerprefab�� ����Ұ���.
        PlayerPrefs.SetInt("BestScore", BestScore);

        Point.text = $"{_score:D6}";
        if (BestScore < _score)
        {
            BestScore = _score;
        }
        BestScoreTextUI.text = $"{BestScore:D6}";
    }
    //��ǥ : score �Ӽ��� ���� ĸ��ȭ(get/set)
    

}
