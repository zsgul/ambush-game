using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Urun : MonoBehaviour
{
    public GameObject[] sekerObje;
    float x, y;
    bool DussunMu = true;
    GameObject SecimAraci;
    public static Urun ilkSecilenUrun;
    public static Urun ikinciSecilenUrun;
    public Vector3 HedefKonum;
    public bool yerDegisim = false;
    public Urun[,] tempUrunKoordinat;
    public List<Urun> silinecekXUrunler;
    public List<Urun> silinecekXUrunler1;
    public List<Urun> silinecekYUrunler;
    public List<Urun> silinecekYUrunler1;
    public List<Urun> silXUrunler;
    public List<Urun> silYUrunler;
    public string renk;
    public int ilkUrunKoordinatX = 0, ilkUrunKoordinatY = 0, ikinciUrunKoordinatX = 0, ikinciUrunKoordinatY = 0;

    void Start()
    {
        tempUrunKoordinat = new Urun[4, 7];
        silinecekXUrunler = new List<Urun>();
        silinecekXUrunler1 = new List<Urun>();
        silinecekYUrunler = new List<Urun>();
        silinecekYUrunler1 = new List<Urun>();
        silXUrunler = new List<Urun>();
        silYUrunler = new List<Urun>();
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

                if (fark_x + fark_y >= -4.29)
                {
                    //KONTROL SAÐLANMADI DÝKKAT!!
                    ilkSecilenUrun.HedefKonum = ikinciSecilenUrun.transform.position; // yer deðiþtirsinler.
                    ikinciSecilenUrun.HedefKonum = ilkSecilenUrun.transform.position;

                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 7; j++)
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

                    ilkSecilenUrun.yerDegisim = true;
                    ikinciSecilenUrun.yerDegisim = true;

                    DegiskenDuzenle();
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
        int ilkSecilenHedefKonumX = 0, ilkSecilenHedefKonumY = 0, ikinciSecilenHedefKonumX = 0, ikinciSecilenHedefKonumY = 0, satirXEslesenler = 1, satirYEslesenler = 1;

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (SekerOlusturma.o_urunler[i, j].x == ilkSecilenUrun.x && SekerOlusturma.o_urunler[i, j].y == ilkSecilenUrun.y)
                {
                    ilkSecilenHedefKonumX = i;
                    ilkSecilenHedefKonumY = j;
                }
                if (SekerOlusturma.o_urunler[i, j].x == ikinciSecilenUrun.x && SekerOlusturma.o_urunler[i, j].y == ikinciSecilenUrun.y)
                {
                    ikinciSecilenHedefKonumX = i;
                    ikinciSecilenHedefKonumY = j;
                }
            }
        }


        int ilkSecilenHedefKonumXTemp = ilkSecilenHedefKonumX, ilkSecilenHedefKonumYTemp = ilkSecilenHedefKonumY, ikinciSecilenHedefKonumXTemp = ikinciSecilenHedefKonumX, ikinciSecilenHedefKonumYTemp = ikinciSecilenHedefKonumY;

        for (int y = ilkSecilenHedefKonumY; y < 7; y++)
        {
            if (y == 6)
            {
                continue;
            }

            if (SekerOlusturma.o_urunler[ilkSecilenHedefKonumX, ilkSecilenHedefKonumYTemp].renk.Replace("(Clone)", "") == SekerOlusturma.o_urunler[ilkSecilenHedefKonumX, ilkSecilenHedefKonumYTemp + 1].renk.Replace("(Clone)", ""))
            {
                satirXEslesenler++;
                silinecekXUrunler.Add(SekerOlusturma.o_urunler[ilkSecilenHedefKonumX, ilkSecilenHedefKonumYTemp + 1]);
            }
            else
            {
                break;
            }

            ilkSecilenHedefKonumYTemp++;
        }

        ilkSecilenHedefKonumYTemp = ilkSecilenHedefKonumY;

        for (int y = ilkSecilenHedefKonumY; y > 0; y--)
        {
            if (y == 0)
            {
                continue;
            }

            if (SekerOlusturma.o_urunler[ilkSecilenHedefKonumX, ilkSecilenHedefKonumYTemp].renk.Replace("(Clone)", "") == SekerOlusturma.o_urunler[ilkSecilenHedefKonumX, ilkSecilenHedefKonumYTemp - 1].renk.Replace("(Clone)", ""))
            {
                satirXEslesenler++;
                silinecekXUrunler1.Add(SekerOlusturma.o_urunler[ilkSecilenHedefKonumX, ilkSecilenHedefKonumYTemp - 1]);
            }
            else
            {
                break;
            }

            ilkSecilenHedefKonumYTemp--;
        }

        if (satirXEslesenler > 2)
        {
            satirXEslesenler = 1;
        }
        else
        {
            satirXEslesenler = 1;
            silinecekXUrunler.Clear();
        }

        for (int y = ikinciSecilenHedefKonumY; y < 7; y++)
        {
            if (y == 6)
            {
                continue;
            }

            if (SekerOlusturma.o_urunler[ikinciSecilenHedefKonumX, ikinciSecilenHedefKonumYTemp].renk.Replace("(Clone)", "") == SekerOlusturma.o_urunler[ikinciSecilenHedefKonumX, ikinciSecilenHedefKonumYTemp + 1].renk.Replace("(Clone)", ""))
            {
                satirXEslesenler++;
                silinecekXUrunler.Add(SekerOlusturma.o_urunler[ikinciSecilenHedefKonumX, ikinciSecilenHedefKonumYTemp + 1]);
            }
            else
            {
                break;
            }

            ikinciSecilenHedefKonumYTemp++;
        }

        ikinciSecilenHedefKonumYTemp = ikinciSecilenHedefKonumY;

        for (int y = ikinciSecilenHedefKonumY; y > 0; y--)
        {
            if (y == 0)
            {
                continue;
            }

            if (SekerOlusturma.o_urunler[ikinciSecilenHedefKonumX, ikinciSecilenHedefKonumYTemp].renk.Replace("(Clone)", "") == SekerOlusturma.o_urunler[ikinciSecilenHedefKonumX, ikinciSecilenHedefKonumYTemp - 1].renk.Replace("(Clone)", ""))
            {
                satirXEslesenler++;
                silinecekXUrunler1.Add(SekerOlusturma.o_urunler[ikinciSecilenHedefKonumX, ikinciSecilenHedefKonumYTemp - 1]);
            }
            else
            {
                break;
            }

            ikinciSecilenHedefKonumYTemp--;
        }

        if (satirXEslesenler > 2)
        {
            satirXEslesenler = 1;
        }
        else
        {
            satirXEslesenler = 1;
            silinecekXUrunler1.Clear();
        }

        for (int x = ilkSecilenHedefKonumX; x < 4; x++)
        {
            if (x == 3)
            {
                continue;
            }

            if (SekerOlusturma.o_urunler[ilkSecilenHedefKonumXTemp, ilkSecilenHedefKonumY].renk.Replace("(Clone)", "") == SekerOlusturma.o_urunler[ilkSecilenHedefKonumXTemp + 1, ilkSecilenHedefKonumY].renk.Replace("(Clone)", ""))
            {
                satirYEslesenler++;
                silinecekYUrunler.Add(SekerOlusturma.o_urunler[ilkSecilenHedefKonumXTemp + 1, ilkSecilenHedefKonumY]);
            }
            else
            {
                break;
            }

            ilkSecilenHedefKonumXTemp++;
        }

        ilkSecilenHedefKonumXTemp = ilkSecilenHedefKonumX;

        for (int x = ilkSecilenHedefKonumX; x > 0; x--)
        {
            if (x == 0)
            {
                continue;
            }

            if (SekerOlusturma.o_urunler[ilkSecilenHedefKonumXTemp, ilkSecilenHedefKonumY].renk.Replace("(Clone)", "") == SekerOlusturma.o_urunler[ilkSecilenHedefKonumXTemp - 1, ilkSecilenHedefKonumY].renk.Replace("(Clone)", ""))
            {
                satirYEslesenler++;
                silinecekYUrunler1.Add(SekerOlusturma.o_urunler[ilkSecilenHedefKonumXTemp - 1, ilkSecilenHedefKonumY]);
            }
            else
            {
                break;
            }

            ilkSecilenHedefKonumXTemp--;
        }

        if (satirYEslesenler > 2)
        {
            satirYEslesenler = 1;
        }
        else
        {
            satirYEslesenler = 1;
            silinecekYUrunler.Clear();
        }

        for (int x = ikinciSecilenHedefKonumX; x < 4; x++)
        {
            if (x == 3)
            {
                continue;
            }

            if (SekerOlusturma.o_urunler[ikinciSecilenHedefKonumXTemp, ikinciSecilenHedefKonumY].renk.Replace("(Clone)", "") == SekerOlusturma.o_urunler[ikinciSecilenHedefKonumXTemp + 1, ikinciSecilenHedefKonumY].renk.Replace("(Clone)", ""))
            {
                satirYEslesenler++;
                silinecekYUrunler.Add(SekerOlusturma.o_urunler[ikinciSecilenHedefKonumXTemp + 1, ikinciSecilenHedefKonumY]);
            }
            else
            {
                break;
            }

            ikinciSecilenHedefKonumXTemp++;
        }

        ikinciSecilenHedefKonumXTemp = ikinciSecilenHedefKonumX;

        for (int x = ikinciSecilenHedefKonumX; x > 0; x--)
        {
            if (x == 0)
            {
                continue;
            }

            if (SekerOlusturma.o_urunler[ikinciSecilenHedefKonumXTemp, ikinciSecilenHedefKonumY].renk.Replace("(Clone)", "") == SekerOlusturma.o_urunler[ikinciSecilenHedefKonumXTemp - 1, ikinciSecilenHedefKonumY].renk.Replace("(Clone)", ""))
            {

                satirYEslesenler++;
                silinecekYUrunler1.Add(SekerOlusturma.o_urunler[ikinciSecilenHedefKonumXTemp - 1, ikinciSecilenHedefKonumY]);
            }
            else
            {
                break;
            }

            ikinciSecilenHedefKonumXTemp--;
        }

        if (satirYEslesenler > 2)
        {
            satirYEslesenler = 1;
        }
        else
        {
            satirYEslesenler = 1;
            silinecekYUrunler1.Clear();
        }

        silXUrunler.AddRange(silinecekXUrunler);
        silXUrunler.AddRange(silinecekXUrunler1);

        silYUrunler.AddRange(silinecekYUrunler);
        silYUrunler.AddRange(silinecekYUrunler1);

        if (silXUrunler.Count > 1)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    foreach (var item in silXUrunler)
                    {
                        if (SekerOlusturma.o_urunler[i, j].x == item.x && SekerOlusturma.o_urunler[i, j].y == item.y)
                        {          
                            uretUrun(i, j, item.x, item.y);
                            Destroy(item.gameObject);
                        }
                    }
                }
            }
           
        }

        if (silYUrunler.Count > 1)
        {

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    foreach (var item in silYUrunler)
                    {
                        if (SekerOlusturma.o_urunler[i, j].x == item.x && SekerOlusturma.o_urunler[i, j].y == item.y)
                        {  
                            uretUrun(i, j, item.x, item.y);
                            Destroy(item.gameObject);
                        }
                    }
                }
            }

        }
        if (silXUrunler.Count == 0 && silYUrunler.Count == 0)
        {
            ilkSecilenUrun.yerDegisim = false;
            ikinciSecilenUrun.yerDegisim = false;
            tempUrunKoordinat[0, 0] = SekerOlusturma.o_urunler[ilkUrunKoordinatX, ilkUrunKoordinatY];
            SekerOlusturma.o_urunler[ilkUrunKoordinatX, ilkUrunKoordinatY] = SekerOlusturma.o_urunler[ikinciUrunKoordinatX, ikinciUrunKoordinatY];
            SekerOlusturma.o_urunler[ikinciUrunKoordinatX, ikinciUrunKoordinatY] = tempUrunKoordinat[0, 0];
        }

        silXUrunler.Clear();
        silYUrunler.Clear();
    }

    void YerDegis()
    {
        transform.position = Vector3.Lerp(transform.position, HedefKonum, 0.1f);
    }

    void uretUrun(int x, int y, float koordinatX, float koordinatY)
    {
      
        int rnd = Random.Range(0, sekerObje.Length);
        GameObject yeniUrun = GameObject.Instantiate(sekerObje[rnd], new Vector2(koordinatX, koordinatY), Quaternion.identity);//Vector2(x,y)
        Urun urun = yeniUrun.GetComponent<Urun>();
        urun.YeniKonum(koordinatX, koordinatY);
        urun.renk = sekerObje[rnd].name;
        urun.renk = urun.renk.Replace("(Clone)", "");
        urun.x = koordinatX;
        urun.y = koordinatY;
        SekerOlusturma.o_urunler[x, y] = urun;

    }
}