using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gorev2 : GorevSistemi
{
    [SerializeField] private GameObject geyik;
    public void Start()
    {
        base.Start();
    }
    void Update()
    {
        GorevKontrol();
    }

    void GorevKontrol()
    {
        if (gorev == 0)
        {
            if(karakter.odunSayisi >= 4)
            {
                GorevKapat(true, true);
                gorev++;
                return;
            }
            if (!yaziyiBastir) return;
            GoreviDegistir(0, 0, 2);
            yaziyiBastir = false;
        }
        if (gorev == 1)
        {
            if (karakter.odunSayisi >= 4)
            {
                GorevKapat(true, true);
                gorev++;
                return;
            }
            if (!yaziyiBastir) return;
            GoreviDegistir(0, 0, 2);
            yaziyiBastir = false;
        }
        if (gorev == 2)
        {
            if (karakter.geyikSayisi == 1)
            {
                GorevKapat(true, true);
                Perde.Instance.Karart();
                gorev++;
                return;
            }
            if (!yaziyiBastir) return;
            GoreviDegistir(0, 0, 2);
            yaziyiBastir = false;
        }
    }
}
