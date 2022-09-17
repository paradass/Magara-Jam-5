using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gorev1 : GorevSistemi
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

    void GorevKontrol()
    {
        if(gorev == 0)
        {
            if (karakter.baltaVarmi)
            {
                GorevKapat(true, true);
                gorev++;
                return;
            }
            if (!yaziyiBastir) return;
            GoreviDegistir(0, 0, 3);
            yaziyiBastir = false;
        }
        if(gorev == 1)
        {
            float mesafe = Vector3.Distance(karakter.transform.position, hedef);
            if(mesafe < 2)
            {
                GorevKapat(true, true);
                gorev++;
                Perde.Instance.Karart();
                return;
            }
            if (!yaziyiBastir) return;
            GoreviDegistir(1, 1, 1);
            yaziyiBastir = false;
        }
    }
}
