using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGame : MonoBehaviour
{

    [SerializeField] private GameObject PausePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


     public void OnPlayButtonClicked()
    {
        //ボタンがクリックされたときの処理
        PausePanel.SetActive(false);
        //カーソルを非表示
        Cursor.visible = false;
        //カーソルを画面中央にロック
        Cursor.lockState = CursorLockMode.Locked;
    }
}
