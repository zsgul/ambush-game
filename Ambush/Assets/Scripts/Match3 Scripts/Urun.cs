using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Urun : MonoBehaviour
{

    float x, y;
    bool DussunMu = true;
    GameObject SecimAraci;
    
    void Start()
    {
        SecimAraci = GameObject.FindGameObjectWithTag("Secim");
    }

    // Update is called once per frame
    void Update()
    {
        if (DussunMu)
        {
            if (transform.position.y - y < 0.05f)
            {
                DussunMu = false;
                transform.position = new Vector3(x, y, 0);
            }

            transform.position = Vector3.Lerp(transform.position, new Vector3(x, y, 0), Time.deltaTime * 3f);
        }
    }

    public void YeniKonum(float _x, float _y)
    {
        x = _x;
        y = _y;

 
    }

    void OnMouseDown()
    {
        SecimAraci.transform.position = transform.position;
    }


}
