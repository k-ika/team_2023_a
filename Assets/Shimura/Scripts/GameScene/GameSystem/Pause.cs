using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject PausePanel;
    
    void Start()
    {
        PausePanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {   
            PausePanel.SetActive(true);
        }

        if (PausePanel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                PausePanel.SetActive(false);
            }
        }
    }
}
