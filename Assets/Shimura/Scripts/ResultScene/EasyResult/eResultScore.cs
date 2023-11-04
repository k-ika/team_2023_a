using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using unityroom.Api;

public class eResultScore : MonoBehaviour
{
    int score;
    //int bombleft;
    float timeleft;
    public int sumscore;

    //[Header("爆弾残量の倍率")] [SerializeField] int multipliedbomb;

    [Header("残り時間の倍率")] [SerializeField] int multipliedtime;

    [Header("Sランクの条件(~以上)")] [SerializeField] int Srank;

    [Header("Aランクの条件(~以上)")] [SerializeField] int Arank;

    [Header("Bランクの条件(~以上)")] [SerializeField] int Brank;

    [Header("Cランクの条件(~未満)")] [SerializeField] int Crank;

    [SerializeField] private GameObject ResultText;

    [SerializeField] private GameObject ScoreText;

    //[SerializeField] private GameObject BombLeftText;

    [SerializeField] private GameObject TimeLeftText;

    [SerializeField] private GameObject SumScoreText;

    [SerializeField] private GameObject RankText;
    [SerializeField] private GameObject madeText;

    [SerializeField] private GameObject SE;

    [SerializeField] private GameObject SE2;


    void Start()
    {
        //セーブデータをロード
        score = PlayerPrefs.GetInt("score", 0);
        //bombleft = PlayerPrefs.GetInt("bombleft", 0);
        timeleft = PlayerPrefs.GetFloat("timeleft", 0);
        //テキストを非表示に
        ResultText.SetActive(false);
        ScoreText.SetActive(false);
        //BombLeftText.SetActive(false);
        TimeLeftText.SetActive(false);
        SumScoreText.SetActive(false);
        RankText.SetActive(false);
        madeText.SetActive(false);
        //何秒かごとに表示させていく
        Invoke("DisplayResultText",1);
        Invoke("DisplayScoretext",2);
        //Invoke("DisplayBombLeftText",3);
        Invoke("DisplayTimeLeftText",3);
        Invoke("DisplaySumScoreText",4);
        Invoke("DisplayRankText",4);
        Invoke("SaveDestroy",4);
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
    //void DisplayBombLeftText()
    //{
    //    BombLeftText.GetComponent<TextMeshProUGUI>().text = "爆弾残量:" + bombleft.ToString("D2");
    //    BombLeftText.SetActive(true);
    //   SE.GetComponent<AudioSource>().Play();
    //}

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
        //sumscore = score + bombleft * multipliedbomb + t * multipliedtime;
        sumscore = score + t * multipliedtime;

        SumScoreText.GetComponent<TextMeshProUGUI>().text = "合計スコア:" + sumscore.ToString("D4");
        SumScoreText.SetActive(true);
        SE2.GetComponent<AudioSource>().Play();
    }

    void DisplayRankText()
    {
        int madeScore;
        if (sumscore >= Srank)
        {
            RankText.GetComponent<TextMeshProUGUI>().text = "Sランク";
            madeText.GetComponent<TextMeshProUGUI>().text = "";
        }

        else if (sumscore >= Arank)
        {
            RankText.GetComponent<TextMeshProUGUI>().text = "Aランク";
            madeScore = Srank - sumscore;
            madeText.GetComponent<TextMeshProUGUI>().text = "Sランクまであと" + madeScore + "点";
        }

        else if (sumscore >= Brank)
        {
            RankText.GetComponent<TextMeshProUGUI>().text = "Bランク";
            madeScore = Arank - sumscore;
            madeText.GetComponent<TextMeshProUGUI>().text = "Aランクまであと" + madeScore + "点";
        }

        else if (sumscore < Crank)
        {
            RankText.GetComponent<TextMeshProUGUI>().text = "Cランク";
            madeScore = Brank - sumscore;
            madeText.GetComponent<TextMeshProUGUI>().text = "Bランクまであと" + madeScore + "点";
        }

        RankText.SetActive(true);
        madeText.SetActive(true);
    }


    //UnityRoomのスコアボードに送信し、Unityの中のセーブデータは消去する
    void SaveDestroy()
    {
        //ボードNo1にsumscoreを送信する。
        //UnityroomApiClient.Instance.SendScore(1, sumscore, ScoreboardWriteMode.Always);
        //ボードNo2にscore（ポイント）を送信する。
        UnityroomApiClient.Instance.SendScore(2, sumscore, ScoreboardWriteMode.Always);
        // 全てのキーとデータを削除
        PlayerPrefs.DeleteAll();
    }
}
