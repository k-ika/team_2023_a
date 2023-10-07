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
    void Start()
    {
        bombtext.GetComponent<TextMeshProUGUI>().text = "×" + bombleft.ToString("D2");
    }

    void Update()
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
                    if (bombleft > redbombleft)
                    {
                        bombtext.GetComponent<TextMeshProUGUI>().color = new Color(1.0f,0.0f,0.0f,1.0f);
                        Invoke("ChangeColor",1.0f);
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

    void ChangeColor()
    {
        bombtext.GetComponent<TextMeshProUGUI>().color = new Color(1.0f,1.0f,1.0f,1.0f);
    }
}