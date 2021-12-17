using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KucukCubukSpawner : MonoBehaviour
{
    public GameObject kucukcubuk;
    

    void Update()
    {
        if (Input.GetMouseButtonDown(0))//sol týklandýðýnda
        {
            KucukCubukSpawn();
        }
    }

    void KucukCubukSpawn()
    {
        //küçük çubuk spawn lokasyonunun positionýnda oluþacak.
        Instantiate(kucukcubuk, transform.position, transform.rotation);
    }

}
