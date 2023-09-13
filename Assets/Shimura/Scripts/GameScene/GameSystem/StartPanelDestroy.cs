using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanelDestroy : MonoBehaviour
{
    [SerializeField] float destroytime = 4;
    [SerializeField] GameObject StartPanel;

    void Start()
    {
        Destroy(StartPanel, destroytime);
    }

    void Update()
    {
        
    }
}
