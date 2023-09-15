using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("移動速度(0.04~0.1くらい)")] [SerializeField] float mainSPEED;　//mainspeedをいじったら移動速度が変わる
    [Header("x方向の視点感度(3~7くらい)")] [SerializeField] float x_sensi;　//これいじったらx方向の視点感度が変わる
    [Header("y方向の視点感度(3~7くらい)")] [SerializeField] float y_sensi;　//これいじったらy方向の視点感度が変わる
    [Header("カメラ")] [SerializeField] new GameObject camera;　//cameraにMainCamera入れといて
    void Start()
    {
    }
 
    void Update()
    {
        movecon();
        cameracon();
    }
 
    void movecon()
    {
        Transform trans = transform;  
        transform.position = trans.position;  //23,24行目は何書いてるか分かれへん
        trans.position += trans.TransformDirection(Vector3.forward) * Input.GetAxis("Vertical") * mainSPEED;
        trans.position += trans.TransformDirection(Vector3.right) * Input.GetAxis("Horizontal") * mainSPEED;
    }
 
    void cameracon()
    {
        float x_Rotation = Input.GetAxis("Mouse X");
        float y_Rotation = Input.GetAxis("Mouse Y");
        x_Rotation = x_Rotation * x_sensi;
        y_Rotation = y_Rotation * y_sensi;
        this.transform.Rotate(0, x_Rotation, 0);
        camera.transform.Rotate(-y_Rotation, 0, 0);
    }
}
