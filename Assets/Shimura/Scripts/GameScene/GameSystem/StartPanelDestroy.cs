using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanelDestroy : MonoBehaviour
{
    public float time = 4;
    //DestroyしたいGameObject(基本はアタッチされたもの)
    public GameObject StartPanel;

    void Start()
    {
        Destroy(StartPanel, time);
    }

    void Update()
    {
        
    }
}
