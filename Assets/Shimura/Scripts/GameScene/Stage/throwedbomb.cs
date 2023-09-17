using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwedbomb : MonoBehaviour
{
    [SerializeField] float motodamage;              //ダメージ

    [SerializeField] float explosionTime;           //爆発までの時間

    [SerializeField] float explosionRange;          //爆発の範囲

    void Start()
    {
        //Invoke("Explode",explosionTime);
    }

    void Update()
    {
        
    }

    //void Explode()
    void OnCollisionEnter(Collision collision)
    {
        //配列yuubakubutusにすべての物や誘爆物を入れる
        GameObject[] yuubakubutus = GameObject.FindGameObjectsWithTag("Yuubakubutu");
        //配列itemsにすべての物や誘爆物を入れる
        GameObject[] items = GameObject.FindGameObjectsWithTag("Item");
        //爆弾の位置
        Vector3 center = this.transform.position;

        //物や誘爆物があれば
        if (yuubakubutus.Length != 0 || items.Length != 0)
        {
            //誘爆物の処理
            foreach (GameObject yuubakubutu in yuubakubutus)
            {
                //爆弾と誘爆物の距離を測定
                float distance = Vector3.Distance(yuubakubutu.transform.position, center);
                //距離が5m以下の時
                if (distance <= 5f)
                {
                    //距離に応じてダメージを受ける
                    yuubakubutu.GetComponent<HpYuubakubutu>().YuubakubutuDamage(motodamage * distance / explosionRange);

                }
            }
            //アイテムの処理
            foreach (GameObject item in items)
            {
                //爆弾と誘爆物の距離を測定
                float distance = Vector3.Distance(item.transform.position, center);
                //距離が5m以下の時
                if (distance <= 5f)
                {
                    //距離に応じてダメージを受ける
                    item.GetComponent<HpMono>().MonoDamage(motodamage * distance / explosionRange);
                }
            }
        }
        Destroy(gameObject);
        //Debug.Log("ドッカーーーン！");
    }
}
