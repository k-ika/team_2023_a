using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] GameObject scoretext;

    int sumscore; 
    void Start()
    {
        scoretext.GetComponent<TextMeshProUGUI>().text = "Score:0000";
    }

    void Update()
    {
        
    }

    public void PlusScore(int score)
    {
        sumscore += score;
        scoretext.GetComponent<TextMeshProUGUI>().text = "Score:" + sumscore.ToString("D4");
    }
}
