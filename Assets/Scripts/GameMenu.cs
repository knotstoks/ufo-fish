using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Continue;
    public GameObject DefeatText;
    public GameObject PauseText;
    bool isPaused = false;

    public void Display()
    {
        if (!isPaused)
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

    public void Defeat()
    {
        isPaused = true;
        Menu.SetActive(true);
        Continue.SetActive(false);
        PauseText.SetActive(false);
        DefeatText.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<FishMovement>().defeat = true;
    }

    public void RetryButton()
    {
        Menu.SetActive(false);
        isPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitButton()
    {
        Display();
        SceneManager.LoadScene(0);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !DefeatText.activeSelf)
        {
            Display();
        }
    }


}
