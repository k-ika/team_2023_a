using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class End : MonoBehaviour
{
    [SerializeField] GameObject GameSystem;

    [SerializeField] GameObject EndPanel;

    [SerializeField] GameObject timetext;

    //GameObject[] yuubakubutus;
    //GameObject[] items;
    void Start()
    {
        EndPanel.SetActive(false);
        //配列yuubakubutusにすべての物や誘爆物を入れる
        //GameObject[] yuubakubutus = GameObject.FindGameObjectsWithTag("Yuubakubutu");
        //配列itemsにすべての物や誘爆物を入れる
        //GameObject[] items = GameObject.FindGameObjectsWithTag("Item");

    }

    void Update()
    {
        if (timetext.GetComponent<TextMeshProUGUI>().text == "0")
        {
            Debug.Log("終了");
            Invoke("LordResult",3);
            EndPanel.SetActive(true);
        }

        if (GameSystem.GetComponent<BombLeft>().bombleft == 0)
        {
            Invoke("LordResult",3);
            EndPanel.SetActive(true);
        }

        //物や誘爆物がすべてなくなれば
        //if (yuubakubutus.Length = 0 & items.Length = 0)
        //{
            //Invoke("LordResult",3);
        //}
    }


    void LordResult()
    {
        SceneManager.LoadScene("Result");
    }

}
