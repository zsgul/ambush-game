using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KucukCubuk : MonoBehaviour
{
    Rigidbody2D rb;
    public float hiz;
    public bool hareketKisitliMi;
    public GameObject yonetici;

    void Start()
    {
        //kod icerisindeki rigidbody yi direkt kucuk cemberin rigidbodysine esitlemek
        rb = GetComponent<Rigidbody2D>();
        //kucukcember prefabi icerisine yoneticiyi ekleyemedigimiz icin kod uzerinden verdik
        yonetici = GameObject.FindGameObjectWithTag("Yonetici");
    }

    void Update()
    {
        // hareket kisitli degilse durmadan yukari ciksin
        if (hareketKisitliMi == false)
        {
            rb.MovePosition(rb.position + Vector2.up * hiz * Time.deltaTime); //rb nin y ekseninde surekli hareket etmesini sagliyoruz.
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "DonenBuyukCember")
        {
            transform.SetParent(col.transform);
            hareketKisitliMi = true;
        }

        if (col.gameObject.tag == "KucukCember") //kucuk cemberler birbirlerine degerse
        {
            yonetici.GetComponent<OyununSonu>().OyunuBitir();
            //Oyunu kaybettiðine dair bir text eklenecek prefab içerisine text eklemeyi öðren!!!!!!!

        }

    }
}
