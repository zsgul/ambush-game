using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject gameMenu, pauseMenu;


    public void PauseButton()
    {
        
        Time.timeScale = 0;
        gameMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void PlayButton()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        gameMenu.SetActive(true);
    }

    public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void MenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

}
