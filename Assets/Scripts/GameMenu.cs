using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    public GameObject Menu;
    bool isPaused = false;

    public void Pause()
    {
        if(!isPaused)
        {
            Time.timeScale = 0;
            isPaused = true;
            Menu.SetActive(true);
        } else
        {
            Time.timeScale = 1;
            isPaused = false;
            Menu.SetActive(false);
        }
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
    }
}
