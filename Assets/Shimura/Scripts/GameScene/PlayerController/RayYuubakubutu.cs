using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayYuubakubutu : MonoBehaviour
{
    [SerializeField] GameObject     MainCamera;             
    [Header("誘爆物が持てる有効距離")] [SerializeField] float      distance = 0.8f;   
    public GameObject Righthand;

    [SerializeField] GameObject crosshair;

    // Hitしたオブジェクト格納用
    public RaycastHit raycastHit;

    void Start()
    {

    }

    void Update()
    {
        // Rayはカメラの位置からとばす
        var rayStartPosition   = MainCamera.transform.position;
        // Rayはカメラが向いてる方向にとばす
        var rayDirection       = MainCamera.transform.forward.normalized;

        // Hitしたオブジェクト格納用
        //RaycastHit raycastHit;

        // Rayを飛ばす（out raycastHit でHitしたオブジェクトを取得する）
        var isHit = Physics.Raycast(rayStartPosition, rayDirection, out raycastHit, distance);
        
        // Debug.DrawRay (Vector3 start(rayを開始する位置), Vector3 dir(rayの方向と長さ), Color color(ラインの色));
        //Debug.DrawRay(rayStartPosition, rayDirection * distance, Color.red);

        //クロスヘアを表示
        crosshair.SetActive(true);
        
        // なにかを検出したら
        if (isHit)
        {
            // LogにHitしたオブジェクト名を出力
            //Debug.Log("HitObject : " + raycastHit.collider.gameObject.name);

            //rayが当たった座標を出力
            //Debug.Log(raycastHit.point);
            

            
            //検出したオブジェクトのタグが"Yuubakubutu"だったとき
            if (raycastHit.collider.CompareTag("Yuubakubutu"))
            {

                //クロスヘアを一旦非表示にする
                crosshair.SetActive(false);

                //右クリックしているとき
                if (Input.GetMouseButtonDown(1))
                {   
                    //Hitしたオブジェクトの名前を変える
                    GameObject HittedObject = raycastHit.collider.gameObject;
                    //Hitしたオブジェクトに右手の座標を代入
                    HittedObject.transform.position = Righthand.transform.position;
                    //親子関係を作る（親：カメラ、子：HittedObject）
                    HittedObject.transform.parent = MainCamera.transform;
                    //HitしたオブジェクトについているRigidbodyを削除する
                    Destroy(HittedObject.GetComponent<Rigidbody>());

                }
            }

            //右クリックを離したとき
            //if (Input.GetMouseButtonUp(1))
            {
                
                //Debug.Log("離した！");
                //HitしたオブジェクトにRayが当たっている座標を代入する
                //HittedObject.transform.position = raycastHit.point;
                //親子関係を解除
                //HittedObject.transform.parent = null;
                //Hitしたオブジェクトのrotationを0に
                //HittedObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }  
        } 

        else 
        {
            //クロスヘアを表示
            crosshair.SetActive(true);
        }
    }
}
