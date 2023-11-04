using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDownScript : MonoBehaviour
{
    [SerializeField] GameObject counttext;

    [Header("3にしといて")]　[SerializeField] float counttime = 3;
    [Header("4にしといて")]　[SerializeField] float hiddentime = 4;
    [SerializeField] GameObject StartPanel;
    void Start()
    {
        //FPSを30に固定
        //Application.targetFrameRate = 30;

        StartPanel.SetActive(true);

        // 全てのキーとデータを削除
        PlayerPrefs.DeleteAll();
        
        Invoke("HiddenStartPanel", hiddentime);
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

    void HiddenStartPanel()
    {
       StartPanel.SetActive(false); 
    }
}
