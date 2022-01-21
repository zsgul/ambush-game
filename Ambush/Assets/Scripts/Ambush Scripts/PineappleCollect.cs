using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PineappleCollect : MonoBehaviour
{

    public AudioSource sesKontrol;
    public AudioClip ananas;
    private int pineapples = 0;

    [SerializeField] private Text pineapplesText;


    void Start()
    {
        sesKontrol = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pineapple"))
        {
            //collectionSoundEffect.Play();
            sesKontrol.PlayOneShot(ananas, 0.5f);
            Destroy(collision.gameObject);
            pineapples++;
            pineapplesText.text = "Pineapples: " + pineapples;
        }
    }
}
