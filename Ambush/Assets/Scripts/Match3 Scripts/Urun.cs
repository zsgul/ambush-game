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
    public List<Urun> urun_x_ekseni;
    public List<Urun> urun_y_ekseni;
    public string renk;

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
                    // ilkSecilenUrun.X_ekseni_kontrol();
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

        int xEslesenler = 1;

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (j == 6)
                {
                    continue;
                }

                if (SekerOlusturma.o_urunler[i, j].renk == SekerOlusturma.o_urunler[i, j+1].renk)
                {
                    xEslesenler++;
                    Debug.Log("X ekseni oynadý");
                    Debug.Log(xEslesenler);
                    //Debug.Log(SekerOlusturma.o_urunler[i, j]);
                }
                else
                {
                    xEslesenler = 1;
                }

                if (xEslesenler > 2)
                {
                    Debug.Log("X ekseninden sil");
                   /* for (int g = 0; g < xEslesenler; g++)
                    {

                    }*/


                }
            }
            xEslesenler = 1;
        }

        for (int j = 0; j < 7; j++)
        {
            for (int i = 0; i < 4; i++)
            {
                
                if (i ==3 )
                {
                    continue;
                }

                if (SekerOlusturma.o_urunler[i, j].renk == SekerOlusturma.o_urunler[i+1, j].renk)
                {
                    Debug.Log("Y ekseni oynadý");
                    Debug.Log(SekerOlusturma.o_urunler[i, j]);
                }
            }
        }


    }

    void YerDegis()
    {

        //for (int i = 0; i < 4; i++)
        //{
        //    for (int j = 0; j < 7; j++)
        //    {
        //        if (true)
        //        {

        //        }
        //    }
        //}
    
        transform.position = Vector3.Lerp(transform.position, HedefKonum, 0.1f);

    }

   /* void X_ekseni_kontrol()
    {
       // Debug.Log(urun);
        int ilkUrunKoordinatX = 0, ilkUrunKoordinatY = 0, ikinciUrunKoordinatX = 0, ikinciUrunKoordinatY = 0;

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (SekerOlusturma.o_urunler[i, j].x == ilkSecilenUrun.x && SekerOlusturma.o_urunler[i, j].y == ilkSecilenUrun.y)
                {
                    ilkUrunKoordinatX = i;
                    ilkUrunKoordinatY = j;
                }
            }
        }

        Urun urun_sagdaki = SekerOlusturma.o_urunler[ilkUrunKoordinatX, ilkUrunKoordinatY];
        if (renk == urun_sagdaki.renk)
        {
            urun_x_ekseni.Add(urun_sagdaki);
        }
        else
        {
           // break;
        }
    }*/
    


















        /* for (int i = x+1; i < SekerOlusturma.o_urunler.GetLength(0);i++) //0 dersem x ekseni için vericek onun yerine  i<6 da denilebilir belki?
         {
             Urun urun_sagdaki = SekerOlusturma.o_urunler[i,y];
             if(renk== urun_sagdaki.renk)
             {
                 urun_x_ekseni.Add(urun_sagdaki);
             }
             else
             {
                 break;
             }
         }
         for (int i = x-1; i>0; i--) //0 dersem x ekseni için vericek onun yerine  i<6 da denilebilir belki?
         {
             Urun urun_sagdaki = SekerOlusturma.o_urunler[i, y];
             if (renk == urun_sagdaki.renk)
             {
                 urun_x_ekseni.Add(urun_sagdaki);
             }
             else
             {
                 break;
             }
         }



     }*/
        /* void Y_ekseni_kontrol()
         {
             for (int i = y + 1; i < SekerOlusturma.o_urunler.GetLength(0); i++) //0 dersem x ekseni için vericek onun yerine  i<6 da denilebilir belki?
             {
                 Urun urun_sagdaki = SekerOlusturma.o_urunler[x,i];
                 if (renk == urun_sagdaki.renk)
                 {
                     urun_y_ekseni.Add(urun_sagdaki);
                 }
                 else
                 {
                     break;
                 }
             }
             for (int i = y - 1; i > 0; i--) //0 dersem x ekseni için vericek onun yerine  i<6 da denilebilir belki?
             {
                 Urun urun_sagdaki = SekerOlusturma.o_urunler[x, i];
                 if (renk == urun_sagdaki.renk)
                 {
                     urun_y_ekseni.Add(urun_sagdaki);
                 }
                 else
                 {
                     break;
                 }
             }
         }*/

    }
