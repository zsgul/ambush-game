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
    public Text sayac, bitis;
    public bool timerStart = false;
    public AudioSource sesKontrol;
    public AudioClip tik;


    void Start()
    {
        sesKontrol = GetComponent<AudioSource>();
    } 


    void Update()
    {
        if (Input.GetMouseButtonDown(0))//sol tiklandiginda
        {
            KucukCubukSpawn();
            spawnCount++;
            if (spawnCount == 10 && timeRemaining > 0)
            {     
                if (Health.currentHealth > 0)
                {
                    Health.currentHealth += 1;
                }
                yonetici.GetComponent<OyununSonu>().OyunuBitir();
                bitis.text = "KAZANDINIZ!!";
            }
        }

        if (timeRemaining > 0 && timerStart)
        {
            timeRemaining -= Time.deltaTime;
            sayac.text = "" + Mathf.Round(timeRemaining);
        }
        if(timeRemaining < 0 && spawnCount < 10)
        {
            yonetici.GetComponent<OyununSonu>().OyunuBitir();
            bitis.text = "KAYBETTİNİZ!!";
        }

    }

    void KucukCubukSpawn()
    {
        //kucuk cubuk spawn lokasyonunun positioninda olusacak.
        Instantiate(kucukCubuk, transform.position, transform.rotation);
        sesKontrol.PlayOneShot(tik, 0.5f);
        timerStart = true;
    }

}
