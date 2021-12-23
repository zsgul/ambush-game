using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SekerOlusturma : MonoBehaviour
{
    public GameObject[] urunler;
    public int row, column;
    public float x = -7.79f, y = -2.88f;

    void Start()
    {
        for(int i=0; i < row; i++)
        {
            for (int j=0; j< column; j++)
            {
                SekerOlustur();
                x += 2.31f;
            }
            y += 1.98f;
            x = -7.79f;
        }
    }

    void Update()
    {
        
    }

    public void SekerOlustur()
    {
        GameObject yeni_urun = GameObject.Instantiate(RandomUrun(), new Vector2(x, y+10), Quaternion.identity);
        yeni_urun.GetComponent<Urun>().YeniKonum(x, y);//yavaþ yavaþ düþmesini saðlýyoruz position deðiþikliði
    }

    public GameObject RandomUrun()
    {
        int rnd = Random.Range(0, urunler.Length);
        return urunler[rnd];
    }
}
