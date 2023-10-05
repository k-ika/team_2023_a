using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sPlayerController : MonoBehaviour
{
    [Header("移動速度(0.04~0.1くらい)")] [SerializeField] float mainSPEED; //mainspeedをいじったら移動速度が変わる
    [Header("x方向の視点感度(3~7くらい)")] [SerializeField] float x_sensi; //これいじったらx方向の視点感度が変わる
    [Header("y方向の視点感度(3~7くらい)")] [SerializeField] float y_sensi; //これいじったらy方向の視点感度が変わる
    [Header("カメラ")] [SerializeField] new GameObject camera; //cameraにMainCamera入れといて

    [Header("正のx座標の限界値")] [SerializeField] float pxLimit;

    [Header("負のx座標の限界値")] [SerializeField] float nxLimit;
    [Header("正のz座標の限界値")] [SerializeField] float pzLimit;

    [Header("負のz座標の限界値")] [SerializeField] float nzLimit;
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

        //追加　現在のポジションを保持する
        Vector3 currentPos = transform.position;
        
        //追加　Mathf.ClampでX,Yの値それぞれが最小～最大の範囲内に収める。
        //範囲を超えていたら範囲内の値を代入する
        currentPos.x = Mathf.Clamp(currentPos.x, nxLimit, pxLimit);
        currentPos.z = Mathf.Clamp(currentPos.z, nzLimit, pzLimit);
        
        //追加　positionをcurrentPosにする
        transform.position = currentPos;
    }
 
    void cameracon()
    {
        float x_Rotation = Input.GetAxis("Mouse X");
        float y_Rotation = Input.GetAxis("Mouse Y");
        x_Rotation = x_Rotation * x_sensi;
        y_Rotation = y_Rotation * y_sensi;
        this.transform.Rotate(0, x_Rotation, 0);
        camera.transform.Rotate(-y_Rotation, 0, 0);
        Vector3 cameraAngle = camera.transform.localEulerAngles;
        if (cameraAngle.x < 280 && cameraAngle.x > 180)
        {
            cameraAngle.x = 280;
        }
        if (cameraAngle.x > 45 && cameraAngle.x < 180)
        {
            cameraAngle.x = 45;
        }
        cameraAngle.y = 0;
        cameraAngle.z = 0;
        camera.transform.localEulerAngles = cameraAngle;
    }
}
