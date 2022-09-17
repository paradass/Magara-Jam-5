using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void GorevKontrol()
    {
        if (gorev == 0)
        {
            if(karakter.odunSayisi >= 4)
            {
                gorev++;
                return;
            }
        }
        if (gorev == 1)
        {
            float mesafe = Vector3.Distance(karakter.transform.position, hedef);
            if (mesafe < 2)
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
}
