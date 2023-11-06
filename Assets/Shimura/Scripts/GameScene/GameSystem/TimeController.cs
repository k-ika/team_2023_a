using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    [SerializeField] GameObject timetext;
    public float timer;

    [SerializeField] private GameObject StartPanel;

    [SerializeField] private GameObject EndPanel;

    [SerializeField] private GameObject PausePanel;

    void Start()
    {
        
    }

    void Update()
    {
        //時間を180から0に一秒ごとに書き換え
        if (timer > 0)
        {
            if (StartPanel.activeSelf || EndPanel.activeSelf || PausePanel.activeSelf)
            {}
            else
            {
                timer -= Time.deltaTime;
            }
            
            timetext.GetComponent<TextMeshProUGUI>().text = timer.ToString("F0");
        }
        //0秒になったら0のままに
        else
        {
            timer = 0;
            //timetext.GetComponent<TextMeshProUGUI>().text = "0";
        }

        if (timer <= 30)
        {
            //赤色にする
            timetext.GetComponent<TextMeshProUGUI>().color = new Color(1.0f, 0f, 0f, 1.0f);
        }
    }
}
