using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class hEnd : MonoBehaviour
{
    [SerializeField] GameObject GameSystem;

    [SerializeField] GameObject EndPanel;

    [SerializeField] GameObject timetext;

    //[Header("スコアの上限（すべてのオブジェクトのスコアの合計値）")] [SerializeField] int maxscore;

    int s;
    int bl;
    float tl;



    void Start()
    {
        EndPanel.SetActive(false);
    }

    void Update()
    {
        //0秒になったらゲーム終了
        if (timetext.GetComponent<TextMeshProUGUI>().text == "0")
        {
            Invoke("EndPanelSet",1);
            Invoke("LoadResult",6);
        }

        //爆弾の残量が0になったらゲーム終了
        if (GameSystem.GetComponent<BombLeft>().bombleft == 0)
        {
            Invoke("EndPanelSet",1);
            Invoke("LoadResult",10);
        }

        //スコアが上限に達したらゲーム終了
        if (GameSystem.GetComponent<DestroyPercent>().percent == 100) //GameSystem.GetComponent<Score>().sumscore == maxscore
        {
            Invoke("EndPanelSet",1);
            Invoke("LoadResult",6);
        }
    }

    void EndPanelSet()
    {
        EndPanel.SetActive(true);
    }


    void LoadResult()
    {
        //変数に代入
        s = GameSystem.GetComponent<Score>().sumscore;
        bl = GameSystem.GetComponent<BombLeft>().bombleft;
        tl = GameSystem.GetComponent<TimeController>().timer;
        //データをセーブ
        PlayerPrefs.SetInt("score", s);
        PlayerPrefs.SetInt("bombleft", bl);
        PlayerPrefs.SetFloat("timeleft", tl);
        //Resultシーンをロード
        SceneManager.LoadScene("hResult");
    }
}
