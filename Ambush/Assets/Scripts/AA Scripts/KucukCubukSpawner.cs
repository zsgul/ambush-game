using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KucukCubukSpawner : MonoBehaviour
{
    public GameObject kucukCubuk;
    

    void Update()
    {
        if (Input.GetMouseButtonDown(0))//sol t�kland���nda
        {
            KucukCubukSpawn();
        }
    }

    void KucukCubukSpawn()
    {
        //k���k �ubuk spawn lokasyonunun position�nda olu�acak.
        Instantiate(kucukCubuk, transform.position, transform.rotation);
    }

}
