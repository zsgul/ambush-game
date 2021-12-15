using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonenBuyukCember : MonoBehaviour
{
    public float hýz;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Rotate(0, 0, hýz * Time.deltaTime);
    }
}
