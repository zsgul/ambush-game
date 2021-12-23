using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Urun : MonoBehaviour
{
    float x, y;
    bool DussunMu=true;

    void Start()
    {
        
    }

    void Update()
    {
        if (DussunMu)
        {
            /*if (transform.position.y - y < 0.2f)
            {
                DussunMu = false;
                transform.position = new Vector3(x, y, 0);
            }*/


            transform.position = Vector3.Lerp(transform.position, new Vector3(x, y, 0), Time.deltaTime * 4f);
        }
    }

    public void YeniKonum(float _x, float _y)
    {
        x = _x;
        y = _y;

    }
}
