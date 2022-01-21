using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SesKontrol : MonoBehaviour
{
    AudioSource sesControl;
  

    void Start()
    {
        sesControl = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("ses") == 1)
        {
            sesControl.mute=false;
            
        }
        else
        {
            sesControl.mute = true;
            
        }
        
    }
}
