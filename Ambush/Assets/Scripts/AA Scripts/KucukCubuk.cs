using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KucukCubuk : MonoBehaviour
{
    //�ubuk b�y�k �embere gidecek ve �ubuklarla �arp���rsa duracak.

    Rigidbody2D rb;
    public float hiz;
    public bool hareketKisitliMi;
    public GameObject yonetici;


    void Start()
    {
        //kod i�erisindeki rigidbody yi direkt k���k �emberin rigidbodysine e�itlemek
        rb = GetComponent<Rigidbody2D>();

        //k���k�ember prefab� i�erisine y�eticiyi ekleyemedi�imiz i�in kod �zerinden verdik
        yonetici = GameObject.FindGameObjectWithTag("Yonetici");
    }

    
    void Update()
    {
        // hareket k�s�tl� de�ilse durmadan yukar� ��ks�n
        if(hareketKisitliMi== false)
        {
            rb.MovePosition(rb.position + Vector2.up * hiz * Time.deltaTime); //rb nin y ekseninde s�rekli hareket etmesini sa�l�yoruz.
        }
        
    }

   

     void OnTriggerEnter2D(Collider2D col)
    {
        //k���k �emberin temas durumunda durmas�n� sa�l�yoruz. Trigger yerine Collision da kullan�labilirdi.
        //Triggerda i�inden ge�ilebilir triggerda en ufak bir temasta durmas�n� sa�lad�k

        if (col.gameObject.tag == "DonenBuyukCember")
        {
            transform.SetParent(col.transform); //DonenbuyukCember tag�na sahip �embere �arpan cisim onunchild� olsun ve onunla beraber d�ns�n
            hareketKisitliMi= true;
        }

        if (col.gameObject.tag == "KucukCember") //kucuk cemberler birbirlerine degerse
        {
            yonetici.GetComponent<OyununSonu>().OyunuBitir();
            
        }


    }

  /*  void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "DonenBuyukCember")
        {
            hareketKisitliMi = true;
        }
    }*/


}
