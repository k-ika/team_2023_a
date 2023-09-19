using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultScore : MonoBehaviour
{
    int score;
    int bombleft;
    float timeleft;

    [Header("爆弾残量の倍率")] [SerializeField] int multipliedbomb;

    [Header("残り時間の倍率")] [SerializeField] int multipliedtime;

    [SerializeField] private GameObject ResultText;

    [SerializeField] private GameObject ScoreText;

    [SerializeField] private GameObject BombLeftText;

    [SerializeField] private GameObject TimeLeftText;

    [SerializeField] private GameObject SumScoreText;


    void Start()
    {
        //セーブデータをロード
        score = PlayerPrefs.GetInt("score", 0);
        bombleft = PlayerPrefs.GetInt("bombleft", 0);
        timeleft = PlayerPrefs.GetFloat("timeleft", 0);
        //テキストを非表示に
        ResultText.SetActive(false);
        ScoreText.SetActive(false);
        BombLeftText.SetActive(false);
        TimeLeftText.SetActive(false);
        SumScoreText.SetActive(false);
        //何秒かごとに表示させていく
        Invoke("DisplayResultText",1);
        Invoke("DisplayScoretext",2);
        Invoke("DisplayBombLeftText",3);
        Invoke("DisplayTimeLeftText",4);
        Invoke("DisplaySumScoreText",5);
        Invoke("SaveDestroy",5);
    }

    void DisplayResultText()
    {
        ResultText.SetActive(true);
    }

    void DisplayScoretext()
    {
        ScoreText.GetComponent<TextMeshProUGUI>().text = "Score:" + score.ToString("D4");
        ScoreText.SetActive(true);
    }

    void DisplayBombLeftText()
    {
        BombLeftText.GetComponent<TextMeshProUGUI>().text = "BombLeft:" + bombleft.ToString("D2");
        BombLeftText.SetActive(true);
    }

    void DisplayTimeLeftText()
    {
        TimeLeftText.GetComponent<TextMeshProUGUI>().text = "TimeLeft:" + timeleft.ToString("F0");
        TimeLeftText.SetActive(true);
    }

    void DisplaySumScoreText()
    {
        //残り時間を四捨五入して整数型に
        int t = Mathf.RoundToInt(timeleft);
        //合計スコアの計算式
        int sumscore = score + bombleft * multipliedbomb + t * multipliedtime;

        SumScoreText.GetComponent<TextMeshProUGUI>().text = "SumScore:" + sumscore.ToString("D4");
        SumScoreText.SetActive(true);
    }

    void SaveDestroy()
    {
        // 全てのキーとデータを削除
        PlayerPrefs.DeleteAll();
    }
}
