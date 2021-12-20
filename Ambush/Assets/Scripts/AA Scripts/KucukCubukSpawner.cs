using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KucukCubukSpawner : MonoBehaviour
{
    public GameObject kucukCubuk;

    public int spawnCount = 0;
    public GameObject yonetici;
    public float timeRemaining = 10;
    public Text sayac;
    public bool timerStart = false;
    



    void Update()
    {
        if (Input.GetMouseButtonDown(0))//sol tiklandiginda
        {
            KucukCubukSpawn();
            spawnCount++;
            if (spawnCount == 10)
            {
                yonetici.GetComponent<OyununSonu>().OyunuBitir();
            }
        }
 

        if (timeRemaining > 0 && timerStart)
        {
            timeRemaining -= Time.deltaTime;
            sayac.text = "" + Mathf.Round(timeRemaining);
        }
    }

    void KucukCubukSpawn()
    {
        //kucuk cubuk spawn lokasyonunun positioninda olusacak.
        Instantiate(kucukCubuk, transform.position, transform.rotation);
        timerStart = true;
    }

}
