using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    [SerializeField] GameObject timetext;
    public float timer;

    void Start()
    {
        
    }

    void Update()
    {
        //時間を180から0に一秒ごとに書き換え
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            timetext.GetComponent<TextMeshProUGUI>().text = timer.ToString("F0");
        }
        //0秒になったら0のままに
        else
        {
            timetext.GetComponent<TextMeshProUGUI>().text = "0";
        }
    }
}
