using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BGMChanger : MonoBehaviour
{

    [SerializeField] GameObject timetext;

    [SerializeField] private GameObject BGM1;
    [SerializeField] private GameObject BGM1Loop;
    [SerializeField] private GameObject BGM2;
    void Start()
    {
        Invoke("BGMLoop", 61);
    }

    void Update()
    {
        if (timetext.GetComponent<TextMeshProUGUI>().text == "30")
        {
            BGM1Loop.GetComponent<AudioSource>().Stop();
            BGM2.GetComponent<AudioSource>().Play();
        }
    }

    void BGMLoop()
    {
        BGM1.GetComponent<AudioSource>().Stop();
        BGM1Loop.GetComponent<AudioSource>().Play();
    }
}
