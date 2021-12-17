using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyununSonu : MonoBehaviour
{
    public GameObject DönenBüyükÇember;
    public GameObject SpawnLokasyonu;

   public void OyunuBitir()
    {
        //DonenBuyukCember Scriptini devre dýþý býrakma
        DönenBüyükÇember.GetComponent<DonenBuyukCember>().enabled = false;
        SpawnLokasyonu.GetComponent<KucukCubukSpawner>().enabled = false;
    }
}
