using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonRanking : MonoBehaviour
{
    [SerializeField] private GameObject Ranking;

    void Start()
    {
        //Rankingを非表示に
        Ranking.SetActive(false);
    }

    void Update()
    {
        
    }

    //ボタンが押されたとき、RankingPanelを表示、非表示にする
    public void OnRankingButtonClick()
    {
        if (Ranking.activeSelf)
        {
            Ranking.SetActive(false);
        }

        else
        {
            Ranking.SetActive(true);
        }
    }
}
