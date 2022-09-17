using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    void SonrakiSahne()
    {
        SceneManager.LoadScene(2);
    }
    void GorevKontrol()
    {
        if(gorev == 0)
        {
            if (karakter.baltaVarmi)
            {
                tekrarla = true;
                gorev++;
                return;
            }
            if (!tekrarla) return;
            Invoke("Diyalog", 1);
            tekrarla = false;

        }
        if(gorev == 1)
        {
            float mesafe = Vector3.Distance(karakter.transform.position, hedef);
            if(mesafe < 2)
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

    void Diyalog()
    {
        if (diyalog == yazilar.Length || yazilar[diyalog] == "") return;
        else
        {
            YaziDegistir(diyalog, diyalog, 0);
            Invoke("Diyalog", sureler[diyalog]);
            diyalog++;
        }
    }
}
