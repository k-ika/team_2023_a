using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigYuubakubutu : MonoBehaviour
{
    //public GameObject MainCamera;
    //[SerializeField] GameObject yuubakubutus;
    //[Header("Player入れといて")]public RayYuubakubutu yuubakubutuScript;
    GameObject BigYuubakubutuBox;
    GameObject Player;
    void Start()
    {
        BigYuubakubutuBox = GameObject.Find("BigYuubakubutuBox");
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        if (this.transform.parent == BigYuubakubutuBox.transform)
        {
            //右クリックを離したとき
            if (Input.GetMouseButtonUp(1))
            {
                //if (yuubakubutuScript.raycastHit.point.x != 0f && yuubakubutuScript.raycastHit.point.y != 0f && yuubakubutuScript.raycastHit.point.z != 0f)

                //if (Player.GetComponent<RayYuubakubutu>().raycastHit.point.x != 0f && Player.GetComponent<RayYuubakubutu>().raycastHit.point.y != 0f && Player.GetComponent<RayYuubakubutu>().raycastHit.point.z != 0f)
                {
                //Debug.Log(yuubakubutuScript.raycastHit.point);

                //Debug.Log("離した！");
                //HitしたオブジェクトにRayが当たっている座標を代入する  //gameObject.transform.position = yuubakubutuScript.raycastHit.point;
                //gameObject.transform.position = Player.GetComponent<RayYuubakubutu>().raycastHit.point;
                //親子関係を解除
                gameObject.transform.parent = null;
                //Hitしたオブジェクトのrotationを0に
                //gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                //このオブジェクトにRigidbodyをつける
                //gameObject.AddComponent<Rigidbody>();     
                //移動速度を遅くする
                Player.GetComponent<sPlayerController>().mainSPEED *= 2.0f;          
                }
            }
        }
    }
}
