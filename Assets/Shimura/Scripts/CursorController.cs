using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //カーソルを非表示
        Cursor.visible = false;
        //カーソルを画面中央にロック
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {   
            //カーソルを表示
            Cursor.visible = true;
            //カーソルを自由に動かせるように
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            //カーソルを非表示
        Cursor.visible = false;
        //カーソルを画面中央にロック
        Cursor.lockState = CursorLockMode.Locked;
        }
    }
}