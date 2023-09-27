using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sEasyScene : MonoBehaviour
{
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
        // プレイボタンがクリックされたときの処理
        Invoke("LoadEasy",1);
    }

    void LoadEasy()
    {
        SceneManager.LoadScene("EasyGameScene");
    }
}
