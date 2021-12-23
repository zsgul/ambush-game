using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Urun : MonoBehaviour
{

    float x, y;
    bool DussunMu = true;
    GameObject SecimAraci;
    public static Urun ilkSecilenUrun;
    public static Urun ikinciSecilenUrun;
    public Vector3 HedefKonum;
    public bool yerDegisim = false;
    public Urun[,] tempUrunKoordinat;

    void Start()
    {
        tempUrunKoordinat = new Urun[4, 7];
        SecimAraci = GameObject.FindGameObjectWithTag("Secim");
    }

    
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

        if (yerDegisim)
        {
            YerDegis();
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
        UrunDurumu();

    }

    void UrunDurumu()
    {
        if (ilkSecilenUrun == null)
        {
            ilkSecilenUrun = this;
        }
        else
        {
            ikinciSecilenUrun = this;
            if (ilkSecilenUrun != ikinciSecilenUrun)
            {
                float fark_x = ilkSecilenUrun.x - ikinciSecilenUrun.x;
                float fark_y = ilkSecilenUrun.y - ikinciSecilenUrun.y;
               // Debug.Log(fark_x + fark_y);

                if (fark_x + fark_y >= -4.29)
                {
                   // Debug.Log("Degissinler");
                    //KONTROL SAÐLANMADI DÝKKAT!!
                    ilkSecilenUrun.HedefKonum = ikinciSecilenUrun.transform.position; // yer deðiþtirsinler.
                    ikinciSecilenUrun.HedefKonum = ilkSecilenUrun.transform.position;
                    ilkSecilenUrun.yerDegisim = true;
                    
                    DegiskenDuzenle();
                          
                    ikinciSecilenUrun.yerDegisim = true;
                    ilkSecilenUrun = null;
             
                }
                else
                {
                    ilkSecilenUrun = ikinciSecilenUrun;
                }
            }
                ikinciSecilenUrun = null;
        }
    }

    void DegiskenDuzenle()
    {
        //Debug.Log(SekerOlusturma.o_urunler[0, 0].x);

        int ilkUrunKoordinatX = 0, ilkUrunKoordinatY = 0, ikinciUrunKoordinatX = 0, ikinciUrunKoordinatY = 0;

        for(int i = 0; i < 4; i++)
        {
            for(int j = 0; j < 7; j++)
            {
                if (SekerOlusturma.o_urunler[i, j].x == ilkSecilenUrun.x && SekerOlusturma.o_urunler[i, j].y == ilkSecilenUrun.y)
                {
                    ilkUrunKoordinatX = i;
                    ilkUrunKoordinatY = j;
                }

                if (SekerOlusturma.o_urunler[i, j].x == ikinciSecilenUrun.x && SekerOlusturma.o_urunler[i, j].y == ikinciSecilenUrun.y)
                {
                    ikinciUrunKoordinatX = i;
                    ikinciUrunKoordinatY = j;
                }
            }
        }

        tempUrunKoordinat[0, 0] = SekerOlusturma.o_urunler[ilkUrunKoordinatX, ilkUrunKoordinatY];
        SekerOlusturma.o_urunler[ilkUrunKoordinatX, ilkUrunKoordinatY] = SekerOlusturma.o_urunler[ikinciUrunKoordinatX, ikinciUrunKoordinatY];
        SekerOlusturma.o_urunler[ikinciUrunKoordinatX, ikinciUrunKoordinatY] = tempUrunKoordinat[0, 0];


        /*Debug.Log(ikinciSecilenUrun.x);
        Debug.Log(ikinciSecilenUrun.y);
        Debug.Log(ilkSecilenUrun.x);
        Debug.Log(ilkSecilenUrun.y);


        SekerOlusturma.o_urunler[(int)ilkSecilenUrun.x, (int)ilkSecilenUrun.y] = ikinciSecilenUrun;
        SekerOlusturma.o_urunler[(int)ikinciSecilenUrun.x, (int)ikinciSecilenUrun.y] = ilkSecilenUrun;
       



        float ilkSecilen_x = ilkSecilenUrun.x;
        float ilkSecilen_y = ilkSecilenUrun.y;

        ilkSecilenUrun.x = ikinciSecilenUrun.x;
        ilkSecilenUrun.y = ikinciSecilenUrun.y;

        ikinciSecilenUrun.x = ilkSecilen_x;
        ikinciSecilenUrun.y = ilkSecilen_y;*/
    }

    void YerDegis()
    {
        transform.position = Vector3.Lerp(transform.position, HedefKonum, 0.1f);
    }

}
