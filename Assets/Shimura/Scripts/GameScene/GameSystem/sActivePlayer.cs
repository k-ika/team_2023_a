using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sActivePlayer : MonoBehaviour
{
    [SerializeField] private GameObject Player;

    [SerializeField] private GameObject GameSystem;

    [SerializeField] private GameObject StartPanel;

    [SerializeField] private GameObject EndPanel;

    [SerializeField] private GameObject PausePanel;

    

    void Start()
    {
        
    }

    void Update()
    {
        if (StartPanel.activeSelf || EndPanel.activeSelf || PausePanel.activeSelf)
        {
            Player.GetComponent<sPlayerController>().enabled = false;
            Player.GetComponent<RayYuubakubutu>().enabled = false;
            Player.GetComponent<CreateBomb>().enabled = false;
        }

        else
        {
            Player.GetComponent<sPlayerController>().enabled = true;
            Player.GetComponent<RayYuubakubutu>().enabled = true;
            Player.GetComponent<CreateBomb>().enabled = true;
        }
    }
}
