using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    [SerializeField] GameObject GameSystem;

    [SerializeField] GameObject EndPanel;

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
        if (GameSystem.GetComponent<TimeController>().timer == 0)
        {
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
