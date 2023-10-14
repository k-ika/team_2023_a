using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RankingScript : MonoBehaviour
{
    [SerializeField] private GameObject ResultManager;
    [SerializeField] private GameObject NewRecordText;
    [SerializeField] private GameObject No1text;
    [SerializeField] private GameObject No2text;
    [SerializeField] private GameObject No3text;
    [SerializeField] private GameObject No4text;
    [SerializeField] private GameObject No5text;
    int newscore;
    static int No1score;
    static int No2score;
    static int No3score;
    static int No4score;
    static int No5score;

    void Start()
    {
        //NewRecordを非表示に
        NewRecordText.SetActive(false);
        //何秒後かに処理するやつ
        Invoke("UpdateRanking",5.01f);
        //テキストに反映
        No1text.GetComponent<TextMeshProUGUI>().text = "1位:" + No1score.ToString("D4");
        No2text.GetComponent<TextMeshProUGUI>().text = "2位:" + No2score.ToString("D4");
        No3text.GetComponent<TextMeshProUGUI>().text = "3位:" + No3score.ToString("D4");
        No4text.GetComponent<TextMeshProUGUI>().text = "4位:" + No4score.ToString("D4");
        No5text.GetComponent<TextMeshProUGUI>().text = "5位:" + No5score.ToString("D4");
    }
    void UpdateRanking()
    {
        //newscoreに現在のスコアを入れる
        newscore = ResultManager.GetComponent<sTajiriResultScore>().sumscore;

        //ここからはランキングの値を更新していく

        //1位のスコアより高いとき
        if (newscore >= No1score)
        {
            No5score = No4score;
            No4score = No3score;
            No3score = No2score;
            No2score = No1score;
            No1score = newscore;
            //NewRecordを表示させる
            NewRecordText.SetActive(true);
        }
        //2位のスコアより高いとき
        else if (newscore >= No2score)
        {
            No5score = No4score;
            No4score = No3score;
            No3score = No2score;
            No2score = newscore;
        }
        //3位のスコアより高いとき
        else if (newscore >= No3score)
        {
            No5score = No4score;
            No4score = No3score;
            No3score = newscore;
        }
        //4位のスコアより高いとき
        else if (newscore >= No4score)
        {
            No5score = No4score;
            No4score = newscore;
        }
        //5位のスコアより高いとき
        else if (newscore > No5score)
        {
            No5score = newscore;
        }

        //テキストに反映
        No1text.GetComponent<TextMeshProUGUI>().text = "1位:" + No1score.ToString("D4");
        No2text.GetComponent<TextMeshProUGUI>().text = "2位:" + No2score.ToString("D4");
        No3text.GetComponent<TextMeshProUGUI>().text = "3位:" + No3score.ToString("D4");
        No4text.GetComponent<TextMeshProUGUI>().text = "4位:" + No4score.ToString("D4");
        No5text.GetComponent<TextMeshProUGUI>().text = "5位:" + No5score.ToString("D4");


    }
}
