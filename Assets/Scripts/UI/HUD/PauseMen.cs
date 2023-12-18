using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMen : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPause;

    void Start()
    {

        pauseMenu.SetActive(false);

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPause = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 1f;
        isPause = true;
    }
}
