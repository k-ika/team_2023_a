using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sTajiriResultScore : MonoBehaviour
{
    int score;
    int bombleft;
    float timeleft;
    public int sumscore;

    [Header("爆弾残量の倍率")] [SerializeField] int multipliedbomb;

    [Header("残り時間の倍率")] [SerializeField] int multipliedtime;

    [Header("Sランクの条件(~以上)")] [SerializeField] int Srank;

    [Header("Aランクの条件(~以上)")] [SerializeField] int Arank;

    [Header("Bランクの条件(~以上)")] [SerializeField] int Brank;

    [Header("Cランクの条件(~未満)")] [SerializeField] int Crank;

    [SerializeField] private GameObject ResultText;

    [SerializeField] private GameObject ScoreText;

    [SerializeField] private GameObject BombLeftText;

    [SerializeField] private GameObject TimeLeftText;

    [SerializeField] private GameObject SumScoreText;

    [SerializeField] private GameObject RankText;

    [SerializeField] private GameObject SE;

    [SerializeField] private GameObject SE2;


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
        RankText.SetActive(false);
        //何秒かごとに表示させていく
        Invoke("DisplayResultText",1);
        Invoke("DisplayScoretext",2);
        Invoke("DisplayBombLeftText",3);
        Invoke("DisplayTimeLeftText",4);
        Invoke("DisplaySumScoreText",5);
        Invoke("DisplayRankText",5);
        Invoke("SaveDestroy",5);
    }


    //Resultのテキストを表示し、音を出させる
    void DisplayResultText()
    {
        ResultText.SetActive(true);
        SE.GetComponent<AudioSource>().Play();
    }


    //ポイントを表示し、音を出す
    void DisplayScoretext()
    {
        ScoreText.GetComponent<TextMeshProUGUI>().text = "ポイント:" + score.ToString("D4");
        ScoreText.SetActive(true);
        SE.GetComponent<AudioSource>().Play();
    }


    //爆弾残量を表示、音を出す
    void DisplayBombLeftText()
    {
        BombLeftText.GetComponent<TextMeshProUGUI>().text = "爆弾残量:" + bombleft.ToString("D2");
        BombLeftText.SetActive(true);
        SE.GetComponent<AudioSource>().Play();
    }

    //残り時間を表示し、音を出す
    void DisplayTimeLeftText()
    {
        TimeLeftText.GetComponent<TextMeshProUGUI>().text = "残り時間:" + timeleft.ToString("F0");
        TimeLeftText.SetActive(true);
        SE.GetComponent<AudioSource>().Play();
    }

    //合計スコアを算出し、表示、音を出す
    void DisplaySumScoreText()
    {
        //残り時間を四捨五入して整数型に
        int t = Mathf.RoundToInt(timeleft);
        //合計スコアの計算式
        sumscore = score + bombleft * multipliedbomb + t * multipliedtime;

        SumScoreText.GetComponent<TextMeshProUGUI>().text = "合計スコア:" + sumscore.ToString("D4");
        SumScoreText.SetActive(true);
        SE2.GetComponent<AudioSource>().Play();
    }

    //合計スコアに応じてランクを判定し、表示
    void DisplayRankText()
    {
        if (sumscore >= Srank)
        {
            RankText.GetComponent<TextMeshProUGUI>().text = "Sランク";
        }

        else if (sumscore >= Arank)
        {
            RankText.GetComponent<TextMeshProUGUI>().text = "Aランク";
        }

        else if (sumscore >= Brank)
        {
            RankText.GetComponent<TextMeshProUGUI>().text = "Bランク";
        }

        else if (sumscore < Crank)
        {
            RankText.GetComponent<TextMeshProUGUI>().text = "Cランク";
        }

        RankText.SetActive(true);

    }


    // 全てのキーとデータを削除
    void SaveDestroy()
    {
        PlayerPrefs.DeleteAll();
    }
}
