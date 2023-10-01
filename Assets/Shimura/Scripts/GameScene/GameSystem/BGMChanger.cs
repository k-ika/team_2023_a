using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BGMChanger : MonoBehaviour
{

    [SerializeField] GameObject timetext;

    [SerializeField] private GameObject BGM1;

    [SerializeField] private GameObject BGM2;
    void Start()
    {
        Invoke("StartBGM",0.1f);
    }

    void Update()
    {
        if (timetext.GetComponent<TextMeshProUGUI>().text == "30")
        {
            BGM1.GetComponent<AudioSource>().Stop();
            BGM2.GetComponent<AudioSource>().Play();
        }
    }

    void StartBGM()
    {
        BGM1.GetComponent<AudioSource>().Play();
    }
}
