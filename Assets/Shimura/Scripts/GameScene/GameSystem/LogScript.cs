using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogScript : MonoBehaviour
{
    [SerializeField] GameObject logtext;

    private string pluspointString;


    void Start()
    {
        logtext.GetComponent<TextMeshProUGUI>().text = "";
    }

    void Update()
    {
        
    }

    public void LogUpdater(string t)
    {
        //logtext.GetComponent<TextMeshProUGUI>().color = new Color(1.0f,1.0f,1.0f,1.0f);
        pluspointString += t;
        logtext.GetComponent<TextMeshProUGUI>().text = pluspointString;
    }
}
