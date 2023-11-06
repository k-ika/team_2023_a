using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDownScript : MonoBehaviour
{
    [SerializeField] GameObject counttext;

    [SerializeField] GameObject StartPanel;
    void Start()
    {
        //FPSを30に固定
        //Application.targetFrameRate = 30;

        StartPanel.SetActive(true);

        // 全てのキーとデータを削除
        PlayerPrefs.DeleteAll();
        
        counttext.GetComponent<TextMeshProUGUI>().text = "";
        Invoke("Count3", 0.0f);
        Invoke("Count2", 1);
        Invoke("Count1", 2);
        Invoke("Count0", 3);
        Invoke("HiddenStartPanel", 4);
    }

    void Update()
    {

    }

    void Count3()
    {
       counttext.GetComponent<TextMeshProUGUI>().text = "3";
    }
    void Count2()
    {
       counttext.GetComponent<TextMeshProUGUI>().text = "2";
    }
    void Count1()
    {
       counttext.GetComponent<TextMeshProUGUI>().text = "1";
    }
    void Count0()
    {
       counttext.GetComponent<TextMeshProUGUI>().text = "Start!";
    }
    void HiddenStartPanel()
    {
       StartPanel.SetActive(false); 
    }
}
