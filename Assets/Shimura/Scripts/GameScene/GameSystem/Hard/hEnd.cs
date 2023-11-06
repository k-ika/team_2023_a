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
    [SerializeField] GameObject Endtext;
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
            Endtext.GetComponent<TextMeshProUGUI>().text = "Time Up!";
            Invoke("EndPanelSet",1);
            Invoke("LoadResult",6);
        }

        //爆弾の残量が0になったらゲーム終了
        if (GameSystem.GetComponent<BombLeft>().bombleft == 0)
        {
            Endtext.GetComponent<TextMeshProUGUI>().text = "Finish!";
            Invoke("EndPanelSet",1);
            Invoke("LoadResult",10);
        }

         //破壊率が100％になったらゲーム終了
        if (GameSystem.GetComponent<DestroyPercent>().percent == 100)
        {
            //黄色にする
            Endtext.GetComponent<TextMeshProUGUI>().color = new Color(1.0f, 0.92f, 0.016f, 1.0f);
            Endtext.GetComponent<TextMeshProUGUI>().text = "Complete!";
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
