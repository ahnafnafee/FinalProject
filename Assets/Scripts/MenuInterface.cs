using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInterface : MonoBehaviour
{
    public GameObject settings;
    public GameObject start;

    private bool isSetting = false;
    
    void Start()
    {
        start.SetActive(true);
        settings.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isSetting)
        {
            start.SetActive(true);
            settings.SetActive(false);
            isSetting = false;
        }
    }


    public void EnterSettings()
    {
        start.SetActive(false);
        settings.SetActive(true);
        isSetting = true;
    }
}
