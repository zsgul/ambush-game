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
    
    void Start()
    {
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
                Debug.Log(fark_x + fark_y);

                if (fark_x + fark_y >= -4.29)
                {
                    Debug.Log("Degissinler");
                    //KONTROL SAÐLANMADI DÝKKAT!!
                    ilkSecilenUrun.HedefKonum = ikinciSecilenUrun.transform.position; // yer deðiþtirsinler.
                    ikinciSecilenUrun.HedefKonum = ilkSecilenUrun.transform.position;
                    ilkSecilenUrun.yerDegisim = true;
                    ikinciSecilenUrun.yerDegisim = true;
                    ilkSecilenUrun = null;
                    ikinciSecilenUrun = null;


                }

                else
                {
                    ilkSecilenUrun = ikinciSecilenUrun;
                    ikinciSecilenUrun = null;
                }
            }
            else
            {
                ikinciSecilenUrun = null;
            }

        }
    }

    void YerDegis()
    {
        transform.position = Vector3.Lerp(transform.position, HedefKonum, 0.1f);
    }

}
