using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BombLeft : MonoBehaviour
{
    [SerializeField] GameObject bombtext;

    public int bombleft;
    void Start()
    {
        bombtext.GetComponent<TextMeshProUGUI>().text = "×" + bombleft.ToString("D2");
    }

    void Update()
    {
        if (bombleft > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                bombleft -= 1;
                bombtext.GetComponent<TextMeshProUGUI>().text = "×" + bombleft.ToString("D2");
            }
        }

        else 
        {
            bombtext.GetComponent<TextMeshProUGUI>().text = "×00";
        }
    }
}