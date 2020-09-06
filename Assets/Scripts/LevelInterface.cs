using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelInterface : MonoBehaviour
{
    public GameObject settings;
    public GameObject pause;

    private bool isSetting = false;
    private bool isPause = false;

    private int index;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        settings.SetActive(false);
        pause.SetActive(false);
        index = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isSetting)
        {
            pause.SetActive(true);
            settings.SetActive(false);
            isSetting = false;
        } else if (Input.GetKeyDown(KeyCode.Escape) && isPause)
        {
            Resume();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            EnterPause();
        }
    }
    
    public void EnterPause()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        pause.SetActive(true);
        GlobalVar.IsPaused = true;
        isPause = true;
    }
    
    public void EnterSettings()
    {
        pause.SetActive(false);
        settings.SetActive(true);
        isSetting = true;
    }

    public void Resume()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pause.SetActive(false);
        isPause = false;
        GlobalVar.IsPaused = false;
        Time.timeScale = 1;
    }

    public void Restart()
    {
        GlobalVar.IsPaused = false;
        SceneManager.LoadSceneAsync(index);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void NextLevel()
    {
        SceneManager.LoadSceneAsync(index + 1);
    }
}
