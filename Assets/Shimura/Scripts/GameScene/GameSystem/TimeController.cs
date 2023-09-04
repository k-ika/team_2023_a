using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    GameObject timetext;
    float timer;

    void Start()
    {
        //シーンにあるTimeというオブジェクトを探して、このスクリプト上で定義
       this.timetext = GameObject.Find("timetext"); 
       timer = 184;
    }

    void Update()
    {
        //時間を180から0に一秒ごとに書き換え
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            this.timetext.GetComponent<TextMeshProUGUI>().text = timer.ToString("F0");
        }
        //0秒になったら0のままに
        else
        {
            this.timetext.GetComponent<TextMeshProUGUI>().text = "0";
        }
    }
}
