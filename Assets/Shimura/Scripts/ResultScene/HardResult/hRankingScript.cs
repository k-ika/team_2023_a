using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class hRankingScript : MonoBehaviour
{
    [SerializeField] private GameObject ResultManager;
    [SerializeField] private GameObject NewRecordText;
    [SerializeField] private GameObject No1text;
    [SerializeField] private GameObject No2text;
    [SerializeField] private GameObject No3text;
    [SerializeField] private GameObject No4text;
    [SerializeField] private GameObject No5text;
    int newscore;
    static int hNo1score;
    static int hNo2score;
    static int hNo3score;
    static int hNo4score;
    static int hNo5score;

    void Start()
    {
        //NewRecordを非表示に
        NewRecordText.SetActive(false);
        //何秒後かに処理するやつ
        Invoke("UpdateRanking",5.01f);
        //テキストに反映
        No1text.GetComponent<TextMeshProUGUI>().text = "1位:" + hNo1score.ToString("D4");
        No2text.GetComponent<TextMeshProUGUI>().text = "2位:" + hNo2score.ToString("D4");
        No3text.GetComponent<TextMeshProUGUI>().text = "3位:" + hNo3score.ToString("D4");
        No4text.GetComponent<TextMeshProUGUI>().text = "4位:" + hNo4score.ToString("D4");
        No5text.GetComponent<TextMeshProUGUI>().text = "5位:" + hNo5score.ToString("D4");
    }
    void UpdateRanking()
    {
        //newscoreに現在のスコアを入れる
        newscore = ResultManager.GetComponent<hResultScore>().sumscore;

        //ここからはランキングの値を更新していく

        //1位のスコアより高いとき
        if (newscore >= hNo1score)
        {
            hNo5score = hNo4score;
            hNo4score = hNo3score;
            hNo3score = hNo2score;
            hNo2score = hNo1score;
            hNo1score = newscore;
            //NewRecordを表示させる
            NewRecordText.SetActive(true);
            Invoke("TikaTika1",0.5f);
        }
        //2位のスコアより高いとき
        else if (newscore >= hNo2score)
        {
            hNo5score = hNo4score;
            hNo4score = hNo3score;
            hNo3score = hNo2score;
            hNo2score = newscore;
        }
        //3位のスコアより高いとき
        else if (newscore >= hNo3score)
        {
            hNo5score = hNo4score;
            hNo4score = hNo3score;
            hNo3score = newscore;
        }
        //4位のスコアより高いとき
        else if (newscore >= hNo4score)
        {
            hNo5score = hNo4score;
            hNo4score = newscore;
        }
        //5位のスコアより高いとき
        else if (newscore > hNo5score)
        {
            hNo5score = newscore;
        }

        //テキストに反映
        No1text.GetComponent<TextMeshProUGUI>().text = "1位:" + hNo1score.ToString("D4");
        No2text.GetComponent<TextMeshProUGUI>().text = "2位:" + hNo2score.ToString("D4");
        No3text.GetComponent<TextMeshProUGUI>().text = "3位:" + hNo3score.ToString("D4");
        No4text.GetComponent<TextMeshProUGUI>().text = "4位:" + hNo4score.ToString("D4");
        No5text.GetComponent<TextMeshProUGUI>().text = "5位:" + hNo5score.ToString("D4");
    }

    void TikaTika1()
    {
        //黄色にする
        NewRecordText.GetComponent<TextMeshProUGUI>().color = new Color(1.0f,0.92f,0.016f,1.0f);
        Invoke("TikaTika2",0.5f);
    }
    void TikaTika2()
    {
        //白にする
        NewRecordText.GetComponent<TextMeshProUGUI>().color = new Color(1.0f,1.0f,1.0f,1.0f);
        Invoke("TikaTika1",0.5f);
    }
}
