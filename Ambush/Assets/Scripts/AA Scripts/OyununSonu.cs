using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyununSonu : MonoBehaviour
{
    public GameObject DonenBuyukCember;
    public GameObject SpawnLokasyonu;

   public void OyunuBitir()
    {
        //DonenBuyukCember Scriptini devre disi birakma
        DonenBuyukCember.GetComponent<DonenBuyukCember>().enabled = false;
        SpawnLokasyonu.GetComponent<KucukCubukSpawner>().enabled = false;
    }
}
