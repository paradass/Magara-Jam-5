using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gorev2 : GorevSistemi
{
    [Space(5)]
    [SerializeField] Vector3 hedef;

    public void Start()
    {
        base.Start();
    }
    void Update()
    {
        GorevKontrol();
    }
    void SonrakiSahne()
    {
        SceneManager.LoadScene(3);
    }
    void GorevKontrol()
    {
        if (gorev == 0)
        {
            if(karakter.odunSayisi >= 4)
            {
                tekrarla = true;
                gorev++;
                return;
            }
            if (!tekrarla) return;
            Invoke("Diyalog", 1f);
            Invoke("AgacKesememe", 35 + 15);
            tekrarla = false;
        }
        if (gorev == 1)
        {
            float mesafe = Vector3.Distance(karakter.transform.position, hedef);
            if (mesafe < 5)
            {
                tekrarla = true;
                gorev++;
                Perde.Instance.Karart();
                Invoke("SonrakiSahne", 2);
                return;
            }
            if (!tekrarla) return;
            CancelInvoke("Diyalog");
            diyalog = 7;
            Invoke("Diyalog", 0.1f);
            tekrarla = false;
        }
    }

    void AgacKesememe()
    {
        if (gorev > 0) return;
        CancelInvoke("Diyalog");
        diyalog = 5;
        Invoke("Diyalog", 0.1f);
    }
}
