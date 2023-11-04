using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DestroyPercent : MonoBehaviour
{
    [SerializeField] GameObject DestroyPertext;

    private int numObject = 0;
    private int numDestroyOb;

    [Header("0のままで")] public float percent;
    void Start()
    {
        //配列yuubakubutusにすべての物や誘爆物を入れる
        GameObject[] yuubakubutus = GameObject.FindGameObjectsWithTag("Yuubakubutu");
        //配列itemsにすべての物や誘爆物を入れる
        GameObject[] items = GameObject.FindGameObjectsWithTag("Item");
        //配列Bigyuubakubutusにすべての物や誘爆物を入れる
        GameObject[] BigYuubakubutus = GameObject.FindGameObjectsWithTag("BigYuubakubutu");

        numObject = yuubakubutus.Length + items.Length + BigYuubakubutus.Length; 
        //テキストの文章を始めに指定
        DestroyPertext.GetComponent<TextMeshProUGUI>().text = "破壊率:0/" + numObject.ToString("D2") + "(0%)";
    }

    void Update()
    {
        
    }


    public void PlusDestroyPer(int dp)
    {
        numDestroyOb += dp;
        percent = 100 * numDestroyOb / numObject;
        DestroyPertext.GetComponent<TextMeshProUGUI>().text = "破壊率:" + numDestroyOb.ToString("D2") + "/" + numObject.ToString("D2") + "(" + percent.ToString("F0")+ "%" + ")";
    }
}
