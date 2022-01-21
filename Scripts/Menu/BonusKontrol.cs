using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BonusKontrol : MonoBehaviour
{
   // public GameObject evetButton, hayirButton;

    public void EvetButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void HayirButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }







}
