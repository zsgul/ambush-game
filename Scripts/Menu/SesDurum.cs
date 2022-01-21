using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SesDurum : MonoBehaviour
{
    public GameObject sesAcik, sesKapali;
 
    void Update()
    {
        if (PlayerPrefs.GetInt("ses") == 1)
        {
            sesAcik.SetActive(true);
            sesKapali.SetActive(false);
        }
        else
        {
            sesAcik.SetActive(false);
            sesKapali.SetActive(true);
        }
    }

    public void sesDurum(string durum)
    {
        if (durum == "acik")
        {
            sesAcik.SetActive(false);
            sesKapali.SetActive(true);
            PlayerPrefs.SetInt("ses", 0);
        }
        else if (durum == "kapali")
        {
            sesAcik.SetActive(true);
            sesKapali.SetActive(false);
            PlayerPrefs.SetInt("ses", 1);
        }



    }




}
