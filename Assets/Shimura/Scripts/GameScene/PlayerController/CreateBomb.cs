using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBomb : MonoBehaviour
{
    float clicktime;
    float starttime;
    //private float x = 0f, y = 0f, time =0f, gravity = 9.8065f, step = 0.05f;
    //private int count;
    [Header("その場に落とす爆弾")] [SerializeField] GameObject puttedbomb;

    [Header("投げる爆弾")] [SerializeField] GameObject throwedbomb;

    [Header("落とす場所")] [SerializeField] GameObject fallpoint;

    [Header("投げ始める場所")] [SerializeField] GameObject throwpoint;
    Rigidbody rb_ball;
    [Header("投げる強さ")] [SerializeField] float thrust = 100f;

    [SerializeField] GameObject GameSystem;

    //[SerializeField] GameObject Line;

    //private LineRenderer bombOrbit;

 
    void Start()
    {
        //bombOrbit = Line.GetComponent<LineRenderer>();
        //bombOrbit.widthMultiplier = 0.00001f;
    }
 
    void Update()
    {
        //ボムの残量が0じゃないとき
        if (GameSystem.GetComponent<BombLeft>().bombleft != -1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //押した時間を記憶
                starttime = Time.time;
                //Lineの幅を0.3秒後に太くする
                //Invoke("WidthLine", 0.3f);
            }

            if (Input.GetMouseButtonUp(0))
            {
                //クリックしていた時間を計算
                clicktime = Time.time - starttime;
                //Debug.Log(clicktime);
                //Lineの幅を0に
                //bombOrbit.widthMultiplier = 0.00001f;
            }

            //クリックした時間に応じてputtedbombを生成
            if (clicktime < 0.3f && clicktime > 0.0001f)
            {
                rb_ball = Instantiate(puttedbomb, fallpoint.transform.position, fallpoint.transform.rotation).GetComponent<Rigidbody>(); // 玉を生成 
                clicktime = 0f;  
            }

            //クリックした時間に応じてthrowedbombを生成
            else if (clicktime >= 0.3f)
            {
                rb_ball = Instantiate(throwedbomb, throwpoint.transform.position, throwpoint.transform.rotation).GetComponent<Rigidbody>(); // 玉を生成
                rb_ball.AddForce(throwpoint.transform.forward * thrust, ForceMode.Impulse); // カーソルの方向に力を一度加える
                clicktime = 0f;
            }
        }
        //CulculateOrbit();
    }


    void CulculateOrbit()
    {
        //if (y >= 0)
        //{
            //x = throwpoint.transform.forward.x * time;
            //y = throwpoint.transform.forward.y * time - 0.5f * gravity * (time * time + time * Time.fixedDeltaTime);
            //bombOrbit.positionCount = count + 1;
            //bombOrbit.SetPosition(count, new Vector3(x, y, 0));
            //count++;
            //time += step;
        //}
    }

    void WidthLine()
    {
        //bombOrbit.widthMultiplier = 100000f;
    }
}
