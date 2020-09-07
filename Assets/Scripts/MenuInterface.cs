using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void StartLevel()
    {
        SceneManager.LoadSceneAsync("Level 1");
    }
    
    public void Quit()
    {
        Application.Quit();
    }

    public void EnterSettings()
    {
        start.SetActive(false);
        settings.SetActive(true);
        isSetting = true;
    }
}
