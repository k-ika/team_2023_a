using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBomb : MonoBehaviour
{
    public GameObject ball;
    Rigidbody rb_ball;
    public float thrust = 100f;
 
    void Start()
    {
        
    }
 
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // マウスの左クリックをしたとき
        {
            rb_ball = Instantiate(ball, transform.position, transform.rotation).GetComponent<Rigidbody>(); // 玉を生成
            rb_ball.AddForce(transform.forward * thrust, ForceMode.Impulse); // カーソルの方向に力を一度加える
        }
    }
}
