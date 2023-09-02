using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDownScript : MonoBehaviour
{
    GameObject counttext;
    float counttime;
    void Start()
    {
         //シーンにあるcouttextというオブジェクトを探して、このスクリプト上で定義
       this.counttext = GameObject.Find("counttext"); 
       counttime = 3;
    }

    void Update()
    {
         //時間を3から1に一秒ごとに書き換え
        if (counttime >= 0.5)
        {
            counttime -= Time.deltaTime;
            this.counttext.GetComponent<TextMeshProUGUI>().text = counttime.ToString("F0");
        }
        //0秒になったらStartに
        else
        {
            this.counttext.GetComponent<TextMeshProUGUI>().text = "Start";
        }
    }
}
