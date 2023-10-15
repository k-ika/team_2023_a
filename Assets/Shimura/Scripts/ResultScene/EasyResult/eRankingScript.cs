using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class eRankingScript : MonoBehaviour
{
    [SerializeField] private GameObject ResultManager;
    [SerializeField] private GameObject NewRecordText;
    [SerializeField] private GameObject No1text;
    [SerializeField] private GameObject No2text;
    [SerializeField] private GameObject No3text;
    [SerializeField] private GameObject No4text;
    [SerializeField] private GameObject No5text;
    int newscore;
    static int eNo1score;
    static int eNo2score;
    static int eNo3score;
    static int eNo4score;
    static int eNo5score;

    void Start()
    {
        //NewRecordを非表示に
        NewRecordText.SetActive(false);
        //何秒後かに処理するやつ
        Invoke("UpdateRanking",5.01f);
        //テキストに反映
        No1text.GetComponent<TextMeshProUGUI>().text = "1位:" + eNo1score.ToString("D4");
        No2text.GetComponent<TextMeshProUGUI>().text = "2位:" + eNo2score.ToString("D4");
        No3text.GetComponent<TextMeshProUGUI>().text = "3位:" + eNo3score.ToString("D4");
        No4text.GetComponent<TextMeshProUGUI>().text = "4位:" + eNo4score.ToString("D4");
        No5text.GetComponent<TextMeshProUGUI>().text = "5位:" + eNo5score.ToString("D4");
    }
    void UpdateRanking()
    {
        //newscoreに現在のスコアを入れる
        newscore = ResultManager.GetComponent<eResultScore>().sumscore;

        //ここからはランキングの値を更新していく

        //1位のスコアより高いとき
        if (newscore >= eNo1score)
        {
            eNo5score = eNo4score;
            eNo4score = eNo3score;
            eNo3score = eNo2score;
            eNo2score = eNo1score;
            eNo1score = newscore;
            //NewRecordを表示させる
            NewRecordText.SetActive(true);
        }
        //2位のスコアより高いとき
        else if (newscore >= eNo2score)
        {
            eNo5score = eNo4score;
            eNo4score = eNo3score;
            eNo3score = eNo2score;
            eNo2score = newscore;
        }
        //3位のスコアより高いとき
        else if (newscore >= eNo3score)
        {
            eNo5score = eNo4score;
            eNo4score = eNo3score;
            eNo3score = newscore;
        }
        //4位のスコアより高いとき
        else if (newscore >= eNo4score)
        {
            eNo5score = eNo4score;
            eNo4score = newscore;
        }
        //5位のスコアより高いとき
        else if (newscore > eNo5score)
        {
            eNo5score = newscore;
        }

        //テキストに反映
        No1text.GetComponent<TextMeshProUGUI>().text = "1位:" + eNo1score.ToString("D4");
        No2text.GetComponent<TextMeshProUGUI>().text = "2位:" + eNo2score.ToString("D4");
        No3text.GetComponent<TextMeshProUGUI>().text = "3位:" + eNo3score.ToString("D4");
        No4text.GetComponent<TextMeshProUGUI>().text = "4位:" + eNo4score.ToString("D4");
        No5text.GetComponent<TextMeshProUGUI>().text = "5位:" + eNo5score.ToString("D4");


    }
}
