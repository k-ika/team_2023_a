using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] GameObject scoretext;

    [Header("0のままで")] public int sumscore; 
    void Start()
    {
        scoretext.GetComponent<TextMeshProUGUI>().text = "ポイント:0000";
    }

    void Update()
    {
        
    }

    public void PlusScore(int score)
    {
        sumscore += score;
        scoretext.GetComponent<TextMeshProUGUI>().text = "ポイント:" + sumscore.ToString("D4");
    }
}
