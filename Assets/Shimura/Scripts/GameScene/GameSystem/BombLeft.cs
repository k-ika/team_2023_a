using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BombLeft : MonoBehaviour
{
    [SerializeField] GameObject bombtext;

    [Header("爆弾の個数")] public int bombleft;

    [Header("爆弾の残量が赤くなり始める数字")] [SerializeField] int redbombleft;

    [SerializeField] private GameObject StartPanel;

    [SerializeField] private GameObject EndPanel;

    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject BombRed;

    void Start()
    {
        //ボムの画像の色を黒にする
        BombRed.SetActive(false);
        //ボムの残量を表示する
        if (bombleft > 1000)
        {
            bombtext.GetComponent<TextMeshProUGUI>().text = "×∞";
        }
        else
        {
            bombtext.GetComponent<TextMeshProUGUI>().text = "×" + bombleft.ToString("D2");
        }
        
    }

    void Update()
    {
        if (bombleft < 500)
        {
                if (bombleft > -1)
            {
                if (StartPanel.activeSelf || EndPanel.activeSelf || PausePanel.activeSelf)
                {

                }
                else
                {
                    if (Input.GetMouseButtonUp(0))
                    {
                        bombleft -= 1;
                        bombtext.GetComponent<TextMeshProUGUI>().text = "×" + bombleft.ToString("D2");
                        //ボムの画像を赤にする
                        BombRed.SetActive(true);
                        Invoke("BombImageChange",1.0f);

                        if (bombleft > redbombleft)
                        {
                            //赤にする
                            bombtext.GetComponent<TextMeshProUGUI>().color = new Color(1.0f,0.0f,0.0f,1.0f);
                            Invoke("BombLeftChangeColor",1.0f);
                        }
                        else
                        {
                            bombtext.GetComponent<TextMeshProUGUI>().color = new Color(1.0f,0.0f,0.0f,1.0f);
                        }
                    }
                }
            }

            else 
            {
                bombtext.GetComponent<TextMeshProUGUI>().text = "×00";
            }
        }
    }

    void BombLeftChangeColor()
    {
        //白にする
        bombtext.GetComponent<TextMeshProUGUI>().color = new Color(1.0f,1.0f,1.0f,1.0f);
    }
    void BombImageChange()
    {
        //ボムの画像を黒に戻す
        BombRed.SetActive(false);
    }
}