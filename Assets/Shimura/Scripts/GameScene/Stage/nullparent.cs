using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nullparent : MonoBehaviour
{
   public GameObject fpsCam;

   public YuubakubutuRay yuubakubutuScript;
    void Start()
    {
        
    }

    void Update()
    {
        if (this.transform.parent == fpsCam.transform)
        {
            //右クリックを離したとき
            if (Input.GetMouseButtonUp(1))
            {
                if (yuubakubutuScript.raycastHit.point.x != 0f && yuubakubutuScript.raycastHit.point.y != 0f && yuubakubutuScript.raycastHit.point.z != 0f)
                {
                //Debug.Log(yuubakubutuScript.raycastHit.point);

                //Debug.Log("離した！");
                //HitしたオブジェクトにRayが当たっている座標を代入する
                this.transform.position = yuubakubutuScript.raycastHit.point;
                //親子関係を解除
                this.transform.parent = null;
                //Hitしたオブジェクトのrotationを0に
                this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                //このオブジェクトにRigidbodyをつける
                this.AddComponent<Rigidbody>();               
                }
            }
        }
    }
}
