using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SekerOlusturma : MonoBehaviour
{
       public GameObject[] pre_urunler;
       public int row, column;
       public float x = -7.79f, y = -2.88f;
       public int urunX = 0, urunY = 0;
       public Urun[,] o_urunler;
    

    void Start()
    {
        o_urunler = new Urun[row, column];

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                SekerOlustur();
                x += 2.31f;
                urunY += 1;
            }
            y += 1.98f;
            x = -7.79f;
            urunX += 1;
            urunY = 0;
        }
    }

    void Update()
    {
        
    }

    public void SekerOlustur()
    {
        GameObject yeni_urun = GameObject.Instantiate(RandomUrun(), new Vector2(x, y+10), Quaternion.identity);
        Urun urun = yeni_urun.GetComponent<Urun>();//yavaþ yavaþ düþmesini saðlýyoruz position deðiþikliði
        urun.YeniKonum(x, y);
        o_urunler[urunX, urunY] = urun; //matris oluþturarak bütün þekerlere istenilen yerden ulaþma
        //Debug.Log(o_urunler[urunX, urunY]);
    }

    public GameObject RandomUrun()
    {
        int rnd = Random.Range(0, pre_urunler.Length);
        return pre_urunler[rnd];
    }
}
