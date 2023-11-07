using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBomb : MonoBehaviour
{
    float clicktime;
    float starttime;
    bool ready = false;
    [Header("その場に落とす爆弾")] [SerializeField] GameObject puttedbomb;

    [Header("投げる爆弾")] [SerializeField] GameObject throwedbomb;

    [Header("落とす場所")] [SerializeField] GameObject fallpoint;

    [Header("投げ始める場所")] [SerializeField] GameObject throwpoint;
    [Header("矢印の画像")] [SerializeField] GameObject Yajirusi;
    Rigidbody rb_ball;
    GameObject ball;
    [Header("投げる強さ")] [SerializeField] float thrust = 100f;

    [SerializeField] GameObject GameSystem;

 
    void Start()
    {
        Yajirusi.SetActive(false);
    }
 
    void Update()
    {
        //ボムの残量が0じゃないとき
        if (GameSystem.GetComponent<BombLeft>().bombleft != 0)
        {
            //押してる間の時間を測る
            if (Input.GetMouseButton(0))
            {
                clicktime += Time.deltaTime;
            }
        }

        //readyがfalseのとき
        if (ready == false)
        {
            //クリックした時間に応じてputtedbombを生成
            if (clicktime < 0.3f && clicktime > 0.0001f)
            {
                //離したとき
                if (Input.GetMouseButtonUp(0))
                {
                    rb_ball = Instantiate(puttedbomb, fallpoint.transform.position, throwedbomb.transform.rotation).GetComponent<Rigidbody>(); // 玉を生成 
                    clicktime = 0f;
                }  
            }
            //クリックした時間が0.3秒を超えると爆弾を右手に表示させる
            else if (clicktime >= 0.3f)
            {
                // 玉を生成
                ball = Instantiate(throwedbomb, throwpoint.transform.position, throwedbomb.transform.rotation); 
                //親子関係を作る
                ball.transform.parent = throwpoint.transform;
                //Rigidbaodyを破棄
                Destroy(ball.GetComponent<Rigidbody>());
                ready = true;
                //Yajirusi.SetActive(true);
            }
        }
            
        if (Input.GetMouseButtonUp(0))
        {
            if (ready == true)
            {
                //親子関係を解徐
                ball.transform.parent = null;
                //Rigidbaody復活
                ball.AddComponent<Rigidbody>();
                //rb_ballに代入
                rb_ball = ball.GetComponent<Rigidbody>();
                //カーソルの方向に力を一度加える
                rb_ball.AddForce(throwpoint.transform.forward * thrust, ForceMode.Impulse);
                clicktime = 0f;
                ready = false;
                //Yajirusi.SetActive(false);
            }
        }
    }
}
