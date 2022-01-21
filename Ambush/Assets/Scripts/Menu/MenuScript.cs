using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour { 

    [Header("UIPages")]
    public GameObject HakkimizdaScreen;
    public GameObject MainScreen;


    public void PlayButton()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       //Application.LoadLevel("Level1");
    }

    public void HakkimizdaButton()
    {
        MainScreen.SetActive(false);
        HakkimizdaScreen.SetActive(true);
    }

    public void Hak2Menu() //geri tuþu
    {
        MainScreen.SetActive(true);
        HakkimizdaScreen.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

}
