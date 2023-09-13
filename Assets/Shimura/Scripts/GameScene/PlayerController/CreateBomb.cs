using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBomb : MonoBehaviour
{
    [SerializeField] GameObject ball;

    [SerializeField] GameObject Righthand;
    Rigidbody rb_ball;
    [SerializeField] float thrust = 100f;

    [SerializeField] GameObject GameSystem;
 
    void Start()
    {
        
    }
 
    void Update()
    {
        if (GameSystem.GetComponent<BombLeft>().bombleft != 0)
        {
            if (Input.GetMouseButtonDown(0)) // マウスの左クリックをしたとき
            {
                rb_ball = Instantiate(ball, Righthand.transform.position, Righthand.transform.rotation).GetComponent<Rigidbody>(); // 玉を生成
                rb_ball.AddForce(transform.forward * thrust, ForceMode.Impulse); // カーソルの方向に力を一度加える
            }
        }
    }
}
