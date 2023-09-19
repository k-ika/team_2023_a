using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yuubakubutu : MonoBehaviour
{
   public GameObject MainCamera;

   [SerializeField] GameObject yuubakubutus;

   [Header("Player入れといて")]public RayYuubakubutu yuubakubutuScript;
    void Start()
    {
        
    }

    void Update()
    {
        if (this.transform.parent == MainCamera.transform)
        {
            //右クリックを離したとき
            if (Input.GetMouseButtonUp(1))
            {
                if (yuubakubutuScript.raycastHit.point.x != 0f && yuubakubutuScript.raycastHit.point.y != 0f && yuubakubutuScript.raycastHit.point.z != 0f)
                {
                //Debug.Log(yuubakubutuScript.raycastHit.point);

                //Debug.Log("離した！");
                //HitしたオブジェクトにRayが当たっている座標を代入する
                gameObject.transform.position = yuubakubutuScript.raycastHit.point;
                //親子関係を解除
                gameObject.transform.parent = yuubakubutus.transform;
                //Hitしたオブジェクトのrotationを0に
                gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                //このオブジェクトにRigidbodyをつける
                gameObject.AddComponent<Rigidbody>();               
                }
            }
        }
    }
}