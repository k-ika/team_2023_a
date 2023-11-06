using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yuubakubutu : MonoBehaviour
{
    //public GameObject MainCamera;
    //[SerializeField] GameObject yuubakubutus;
    //[Header("Player入れといて")]public RayYuubakubutu yuubakubutuScript;
    GameObject MainCamera;
    GameObject yuubakubutus;
    GameObject Player;
    void Start()
    {
        MainCamera = GameObject.Find("MainCamera");
        yuubakubutus = GameObject.Find("Yuubakubutus");
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        if (this.transform.parent == MainCamera.transform)
        {
            //右クリックを離したとき
            if (Input.GetMouseButtonUp(1))
            {
                //if (yuubakubutuScript.raycastHit.point.x != 0f && yuubakubutuScript.raycastHit.point.y != 0f && yuubakubutuScript.raycastHit.point.z != 0f)

                if (Player.GetComponent<RayYuubakubutu>().raycastHit.point.x != 0f && Player.GetComponent<RayYuubakubutu>().raycastHit.point.y != 0f && Player.GetComponent<RayYuubakubutu>().raycastHit.point.z != 0f)
                {
                    //HitしたオブジェクトにRayが当たっている座標を代入する  //gameObject.transform.position = yuubakubutuScript.raycastHit.point;
                    gameObject.transform.position = Player.GetComponent<RayYuubakubutu>().raycastHit.point;
                    //親子関係を解除
                    gameObject.transform.parent = yuubakubutus.transform;
                    //このオブジェクトにRigidbodyをつける
                    gameObject.AddComponent<Rigidbody>();
                    //埋め込み防止用に位置を制限
                    if (gameObject.transform.position.y < 0.5f)
                    {
                        Vector3 Pos = gameObject.transform.position;
                        Pos.y = 0.5f;
                        gameObject.transform.position = Pos;
                    }
                    else if (gameObject.transform.position.y > 4.0f)
                    {
                        Vector3 Pos = gameObject.transform.position;
                        Pos.y = 4.0f;
                        gameObject.transform.position = Pos;
                    }
                    else if (gameObject.transform.position.x > 9.0f)
                    {
                        Vector3 Pos = gameObject.transform.position;
                        Pos.x = 9.0f;
                        gameObject.transform.position = Pos;
                    }
                    else if (gameObject.transform.position.x < -9.0f)
                    {
                        Vector3 Pos = gameObject.transform.position;
                        Pos.x = -9.0f;
                        gameObject.transform.position = Pos;
                    }
                }
            }
        }
    }
}
