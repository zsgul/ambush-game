using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KucukCubuk : MonoBehaviour
{
    //Çubuk büyük çembere gidecek ve çubuklarla çarpýþýrsa duracak.

    Rigidbody2D rb;
    public float hýz;
    public bool hareketkýsýtlýmý;
    public GameObject yönetici;


    void Start()
    {
        //kod içerisindeki rigidbody yi direkt küçük çemberin rigidbodysine eþitlemek
        rb = GetComponent<Rigidbody2D>();

        //küçükçember prefabý içerisine yöeticiyi ekleyemediðimiz için kod üzerinden verdik
        yönetici = GameObject.FindGameObjectWithTag("Yonetici");
    }

    
    void Update()
    {
        // hareket kýsýtlý deðilse durmadan yukarý çýksýn
        if(hareketkýsýtlýmý== false)
        {
            rb.MovePosition(rb.position + Vector2.up * hýz * Time.deltaTime); //rb nin y ekseninde sürekli hareket etmesini saðlýyoruz.
        }
        
    }

   

     void OnTriggerEnter2D(Collider2D col)
    {
        //küçük çemberin temas durumunda durmasýný saðlýyoruz. Trigger yerine Collision da kullanýlabilirdi.
        //Triggerda içinden geçilebilir triggerda en ufak bir temasta durmasýný saðladýk

        if (col.gameObject.tag == "DonenBuyukCember")
        {
            transform.SetParent(col.transform); //DonenbuyukCember tagýna sahip çembere çarpan cisim onunchildý olsun ve onunla beraber dönsün
            hareketkýsýtlýmý = true;
        }

        if (col.gameObject.tag == "KucukCember") //küçükçemberler birbirlerine deðerse
        {
            yönetici.GetComponent<OyununSonu>().OyunuBitir();
            
        }


    }

  /*  void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "DonenBuyukCember")
        {
            hareketkýsýtlýmý = true;
        }
    }*/


}
