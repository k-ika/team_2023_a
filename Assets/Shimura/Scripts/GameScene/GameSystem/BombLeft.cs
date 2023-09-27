using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BombLeft : MonoBehaviour
{
    [SerializeField] GameObject bombtext;

    [Header("爆弾の個数")] public int bombleft;

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
                }
            }
        }

        else 
        {
            bombtext.GetComponent<TextMeshProUGUI>().text = "×00";
        }
    }
}