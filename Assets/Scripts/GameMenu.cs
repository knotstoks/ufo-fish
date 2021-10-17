using UnityEngine;
using UnityEngine.UI;
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
        Time.timeScale = 0;
        isPaused = true;
        Menu.SetActive(true);
        Continue.SetActive(false);
        PauseText.SetActive(false);
        DefeatText.SetActive(true);

    }

    public void RetryButton()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        Menu.SetActive(false);
        isPaused = false;
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
