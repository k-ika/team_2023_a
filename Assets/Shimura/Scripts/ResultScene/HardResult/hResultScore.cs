using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using unityroom.Api;

public class hResultScore : MonoBehaviour
{
    int score;
    int bombleft;
    float timeleft;
    public int sumscore;

    [Header("爆弾残量の倍率")] [SerializeField] int multipliedbomb;

    [Header("残り時間の倍率")] [SerializeField] int multipliedtime;
    [Header("Godランクの条件(~以上)")] [SerializeField] int Godrank;
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
    [SerializeField] private GameObject madeText;

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
        madeText.SetActive(false);
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

    void DisplayRankText()
    {
        int madeScore;
        if (sumscore >= Godrank)
        {
            RankText.GetComponent<TextMeshProUGUI>().text = "Godランク";
            madeText.GetComponent<TextMeshProUGUI>().text = "";
            Invoke("TikaTika1",0.0f);
        }

        else if (sumscore >= Srank)
        {
            //黄色にする
            RankText.GetComponent<TextMeshProUGUI>().color = new Color(1.0f,0.92f,0.016f,1.0f);
            RankText.GetComponent<TextMeshProUGUI>().text = "Sランク";
            madeText.GetComponent<TextMeshProUGUI>().text = "";
        }

        else if (sumscore >= Arank)
        {
            //赤色にする
            RankText.GetComponent<TextMeshProUGUI>().color = new Color(1.0f,0.0f,0.0f,1.0f);
            RankText.GetComponent<TextMeshProUGUI>().text = "Aランク";
            madeScore = Srank - sumscore;
            madeText.GetComponent<TextMeshProUGUI>().text = "Sランクまであと" + madeScore + "点";
        }

        else if (sumscore >= Brank)
        {
            //青色にする
            RankText.GetComponent<TextMeshProUGUI>().color = new Color(0.0f,0.0f,1.0f,1.0f);
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
        UnityroomApiClient.Instance.SendScore(1, sumscore, ScoreboardWriteMode.Always);
        //ボードNo2にscore（ポイント）を送信する。
        //UnityroomApiClient.Instance.SendScore(2, score, ScoreboardWriteMode.Always);
        // 全てのキーとデータを削除
        PlayerPrefs.DeleteAll();
    }

    void TikaTika1()
    {
        //赤色にする
        RankText.GetComponent<TextMeshProUGUI>().color = new Color(1.0f,0.0f,0.0f,1.0f);
        Invoke("TikaTika2",0.25f);
    }
    void TikaTika2()
    {
        //黄色にする
        RankText.GetComponent<TextMeshProUGUI>().color = new Color(1.0f,0.92f,0.016f,1.0f);
        Invoke("TikaTika3",0.25f);
    }
    void TikaTika3()
    {
        //オレンジのの16進数
        string colorString = "#FF9600";
        Color newColor1;
        ColorUtility.TryParseHtmlString(colorString, out newColor1);
        RankText.GetComponent<TextMeshProUGUI>().color = newColor1;
        Invoke("TikaTika4",0.25f);
    }
    void TikaTika4()
    {
        //緑にする
        RankText.GetComponent<TextMeshProUGUI>().color = new Color(0.0f,1.0f,0.0f,1.0f);
        Invoke("TikaTika5",0.25f);
    }
    void TikaTika5()
    {
        //水色(シアン)にする
        RankText.GetComponent<TextMeshProUGUI>().color = new Color(0.0f,1.0f,1.0f,1.0f);
        Invoke("TikaTika6",0.25f);
    }
    void TikaTika6()
    {
        //青色にする
        RankText.GetComponent<TextMeshProUGUI>().color = new Color(0.0f,0.0f,1.0f,1.0f);
        Invoke("TikaTika7",0.25f);
    }
    void TikaTika7()
    {
        //紫の16進数
        string colorString = "#9600FF";
        Color newColor2;
        ColorUtility.TryParseHtmlString(colorString, out newColor2); // 新しくColorを作成
        //紫にする
        RankText.GetComponent<TextMeshProUGUI>().color = newColor2;
        Invoke("TikaTika1",0.25f);
    }
}
