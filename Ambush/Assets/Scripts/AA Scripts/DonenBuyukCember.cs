using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonenBuyukCember : MonoBehaviour
{
    public float hiz;
  

    
    void Update()
    {
        transform.Rotate(0, 0, hiz * Time.deltaTime);
    }
}
