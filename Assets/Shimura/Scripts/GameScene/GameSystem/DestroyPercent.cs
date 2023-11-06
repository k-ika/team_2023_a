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
        //破壊されたオブジェクトの個数を加算
        numDestroyOb += dp;
        //破壊率を計算
        percent = 100 * numDestroyOb / numObject;
        //ゲーム画面上に反映
        DestroyPertext.GetComponent<TextMeshProUGUI>().color = new Color(0.0f,1.0f,1.0f,1.0f);
        DestroyPertext.GetComponent<TextMeshProUGUI>().text = "破壊率:" + numDestroyOb.ToString("D2") + "/" + numObject.ToString("D2") + "(" + percent.ToString("F0")+ "%" + ")";
        Invoke("TextChangeColor",0.5f);
    }
    void TextChangeColor()
    {
        DestroyPertext.GetComponent<TextMeshProUGUI>().color = new Color(1.0f,1.0f,1.0f,1.0f);
    }
}
