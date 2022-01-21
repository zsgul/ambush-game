using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OyununSonu : MonoBehaviour
{
    public GameObject DonenBuyukCember;
    public GameObject SpawnLokasyonu;

   public void OyunuBitir()
    {
        Invoke("OyunuBitir", 100f);
        //DonenBuyukCember Scriptini devre disi birakma
        DonenBuyukCember.GetComponent<DonenBuyukCember>().enabled = false;
        SpawnLokasyonu.GetComponent<KucukCubukSpawner>().enabled = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
}
