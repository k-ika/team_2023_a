using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBomb : MonoBehaviour
{
    float clicktime;
    float starttime;
    [Header("その場に落とす爆弾")]　[SerializeField] GameObject puttedbomb;

    [Header("投げる爆弾")]　[SerializeField] GameObject throwedbomb;

    [Header("落とす場所")] [SerializeField] GameObject fallpoint;

    [Header("投げ始める場所")] [SerializeField] GameObject throwpoint;
    Rigidbody rb_ball;
    [Header("投げる強さ")]　[SerializeField] float thrust = 100f;

    [SerializeField] GameObject GameSystem;
 
    void Start()
    {
        
    }
 
    void Update()
    {
        //クリックしている時間を調べる
        if (Input.GetMouseButtonDown(0))
        {
            starttime = Time.time;
        }

        if (Input.GetMouseButtonUp(0))
        {
            clicktime = Time.time - starttime;
            //Debug.Log(clicktime);
        }

        //ボムの残量が0じゃないとき
        if (GameSystem.GetComponent<BombLeft>().bombleft != -1)
        {
            if (clicktime < 0.3f && clicktime > 0.0001f)
            {
                rb_ball = Instantiate(puttedbomb, fallpoint.transform.position, fallpoint.transform.rotation).GetComponent<Rigidbody>(); // 玉を生成 
                clicktime = 0f;  
            }

            else if (clicktime >= 0.3f)
            {
                rb_ball = Instantiate(throwedbomb, throwpoint.transform.position, throwpoint.transform.rotation).GetComponent<Rigidbody>(); // 玉を生成
                rb_ball.AddForce(throwpoint.transform.forward * thrust, ForceMode.Impulse); // カーソルの方向に力を一度加える
                clicktime = 0f;
            }
        }
    }
}
